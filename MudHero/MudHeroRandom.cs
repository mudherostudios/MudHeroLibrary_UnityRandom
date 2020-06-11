using UnityEngine;
using System;
using System.Collections.Generic;
using NPack;
using URandom;

/////////////////////////////////////////////////////////////////////////////
//                                                                         //
// Mud Hero Random                                                         //
//                                                                         //
// This code is free software under the Artistic license.                  //
//                                                                         //
// distributions mainly from: http://www.nrbook.com/a/bookcpdf.php         //
//                                                                         //
// Note from Codie: Got this here https://github.com/tucano/UnityRandom    //
/////////////////////////////////////////////////////////////////////////////

public class MudHeroRandom 
{
	public static int max_seed = Int32.MaxValue;
	
	public enum Normalization
	{
		STDNORMAL = 0,
		POWERLAW = 1
	}
		
	private MersenneTwister _rand;
	public MudHeroRandom() {  _rand = new MersenneTwister(); } 
	public MudHeroRandom(int seed) { _rand = new MersenneTwister(seed); }
    public float Value() { return _rand.NextSingle(true); }
	public float Value( Normalization n , float t)
	{
		if (n == Normalization.STDNORMAL) return (float) NormalDistribution.Normalize(_rand.NextSingle(true), t);
        else if (n == Normalization.POWERLAW) return (float) PowerLaw.Normalize(_rand.NextSingle(true), t, 0, 1);
        else return _rand.NextSingle(true);
	}

    public float Range(Int32 minValue, Int32 maxValue) { return _rand.Next(minValue, maxValue); }
	public float Range(Int32 minValue, Int32 maxValue, Normalization n, float t)
	{
		if (n == Normalization.STDNORMAL) return SpecialFunctions.ScaleFloatToRange( (float) NormalDistribution.Normalize(_rand.NextSingle(true), t), minValue, maxValue, 0, 1);
		else if (n == Normalization.POWERLAW) return (float) PowerLaw.Normalize(_rand.NextSingle(true), t, minValue, maxValue);
		else return _rand.Next(minValue, maxValue);
	}
     
    public float Possion(float lambda) { return PoissonDistribution.Normalize(ref _rand, lambda); } 
	public float Exponential(float lambda) { return ExponentialDistribution.Normalize( _rand.NextSingle( false ), lambda ); }
    public float Gamma(float order) { return GammaDistribution.Normalize(ref _rand, (int) order); }
	public Vector2 PointInASquare() { return RandomSquare.Area(ref _rand); }
	public Vector2 PointInASquare(Normalization n , float t ) { return RandomSquare.Area(ref _rand, n, t); }
	public Vector2 PointInACircle()  { return RandomDisk.Circle(ref _rand); }
	public Vector2 PointInACircle(Normalization n, float t) { return RandomDisk.Circle(ref _rand, n, t); }
	public Vector2 PointInADisk() { return RandomDisk.Disk(ref _rand); }
	public Vector2 PointInADisk(Normalization n, float t) { return RandomDisk.Disk(ref _rand, n, t); }
	public Vector3 PointInACube() { return RandomCube.Volume(ref _rand); }
	public Vector3 PointInACube(Normalization n, float t) { return RandomCube.Volume(ref _rand, n, t); }
	public Vector3 PointOnACube() { return RandomCube.Surface(ref _rand); } 
	public Vector3 PointOnACube(Normalization n, float t) { return RandomCube.Surface(ref _rand, n, t); } 
	public Vector3 PointOnASphere() { return RandomSphere.Surface(ref _rand); } 
	public Vector3 PointOnASphere(Normalization n, float t) { throw new ArgumentException("Normalizations for Sphere is not yet implemented"); }
	public Vector3 PointInASphere() { return RandomSphere.Volume(ref _rand); } 
	public Vector3 PointInASphere(Normalization n, float t) { throw new ArgumentException("Normalizations for Sphere is not yet implemented"); }
    public Vector3 PointOnCap(float spotAngle) { return RandomSphere.GetPointOnCap(spotAngle, ref _rand); }	 
	public Vector3 PointOnCap(float spotAngle, Normalization n, float t) { throw new ArgumentException("Normalizations for PointOnCap is not yet implemented"); }
	public Vector3 PointOnRing(float innerAngle, float outerAngle) { return RandomSphere.GetPointOnRing(innerAngle, outerAngle, ref _rand); }
	public Vector3 PointOnRing(float innerAngle, float outerAngle, Normalization n, float t) { throw new ArgumentException("Normalizations for PointOnRing is not yet implemented"); } 
	public Color Rainbow() { return WaveToRgb.LinearToRgb(_rand.NextSingle(true)); } 
	public Color Rainbow(Normalization n, float t)
	{
		if (n == Normalization.STDNORMAL) return WaveToRgb.LinearToRgb ( (float) NormalDistribution.Normalize(_rand.NextSingle(true), t));
		else if (n == Normalization.POWERLAW) return WaveToRgb.LinearToRgb ( (float) PowerLaw.Normalize(_rand.NextSingle(true), t, 0, 1));
		else return WaveToRgb.LinearToRgb(_rand.NextSingle(true));
	} 

	public DiceRoll RollDice(int size, DiceRoll.DiceType type) { DiceRoll roll = new DiceRoll(size, type, ref _rand); return roll; }
	
	public ShuffleBagCollection<float> ShuffleBag(float[] values)
	{
		ShuffleBagCollection<float> bag = new ShuffleBagCollection<float>();
		foreach (float x in values) 
			bag.Add(x); 
		return bag;
	}
 
	public ShuffleBagCollection<float> ShuffleBag(Dictionary<float,int> dict)
	{
		ShuffleBagCollection<float> bag = new ShuffleBagCollection<float>();
		foreach (KeyValuePair<float, int> x in dict)
		{ 
			int val = x.Value;
			float key = x.Key;
			bag.Add( key, val);
		}
		return bag;
	}
}
