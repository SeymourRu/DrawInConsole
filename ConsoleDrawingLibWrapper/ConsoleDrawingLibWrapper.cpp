// This is the main DLL file.

#include "stdafx.h"
#include <string>

using namespace System;
using namespace ConsoleDrawingLib;
using namespace System::Collections;


extern "C"
{
	void __declspec(dllexport) __stdcall Test()
	{
		Console::WriteLine("TEST");
	}

	void __declspec(dllexport) __stdcall DrawPicture(wchar_t* path, int x, int y, int width, int heigth)
	{
		//Console::WriteLine("Before call PictureWriter::DrawAPicture");
		ConsoleDrawingLib::PictureWriter::DrawAPicture(gcnew System::String(path), x, y, width, heigth);
		//Console::WriteLine("After call PictureWriter::DrawAPicture");
	}

	void __declspec(dllexport) __stdcall DrawPictureC(const wchar_t* path, int x, int y, int width, int heigth)
	{
		//Console::WriteLine("Before call PictureWriter::DrawAPicture");
		ConsoleDrawingLib::PictureWriter::DrawAPicture(gcnew System::String(path), x, y, width, heigth);
		//Console::WriteLine("After call PictureWriter::DrawAPicture");
	}
}