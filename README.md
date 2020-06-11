# MudHeroLibrary_UnityRandom

This is actually pretty much a manual fork and edit of [this project](https://github.com/tucano/UnityRandom). I did end up editting some of the code because it was causing a few problems and is kind of messy for reading. Still haven't refactored it fully and prettified it but I'll slowly tweak it here and there.

## Purpose
The reason I use this in my Xaya Unity projects is because I need an extensible and fully transparent random library I can rely on. In blockchain games everything needs to be done the same way on all computers and devices. I don't know the particulars of every platform and system random libraries. That can be bad for calculating the game state on cross platform situations (which ideally most blockchain games should be). Because the random libraries methods are opaque to me, I opted to use an open source random library I could view, extend, and debug. Additionally this project has several unity specific random generators.

## Requirements
This is not a compilable library in visual studio or any other IDE, it references UnityEngine and several classes like Vector3. So if you want to use this library it must be used in Unity as uncompiled code. If you really want to use it in your C# project, you will either need to provide a couple of extra classes, like Vector3 and Color or just delete the unity specific ones. But mostly its just useful for Unity stuff and I would probably search for another opensource random project before you think about editting this one. I don't think it would be hard, but maybe you just want to use something right now. Which this one would require some editting.

## Usage
Just drop the two folders in a arbitrary folder (I put all of my scripts in a Scripts folder) in your Unity project. It should work without any additional effort. I have only tested it on Unity 2018 - 2019.3.13f1. I'm not sure if they work on other versions.
