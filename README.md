# DrawInConsole

How to:

	.Net [ public static void DrawAPicture(string picturePath,int x,int y, int width, int heigth) ]
		1) Add assembly reference to ConsoleDrawingLib.dll
		2) Call ConsoleDrawingLib.PictureWriter.DrawAPicture method	with required params
    
	C++ [ void __declspec(dllexport) DrawPicture(const wchar_t* path, int x, int y, int width, int heigth) ]
		1) LoadLibrary ConsoleDrawingLibWrapper
		2) GetProcAddress "DrawPicture"
		3) Call function pointer with required params
