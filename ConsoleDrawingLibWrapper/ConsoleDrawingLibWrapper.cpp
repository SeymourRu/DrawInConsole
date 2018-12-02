// This is the main DLL file.

#include "stdafx.h"
#include <string>

using namespace System;
using namespace ConsoleDrawingLib;
using namespace System::Collections;


extern "C"
{
	void __declspec(dllexport) TestTextOutput()
	{
		Console::WriteLine("Testing console output");
		Console::WriteLine("Test message");
		Console::WriteLine("End testing console output");
	}

	void __declspec(dllexport) TestTextOutputStr(wchar_t* text)
	{
		Console::WriteLine("Testing console output");
		Console::WriteLine(gcnew System::String(text));
		Console::WriteLine("End testing console output");
	}

	void __declspec(dllexport) DrawPictureDebug(wchar_t* path, int x, int y, int width, int heigth)
	{
		Console::WriteLine("Before call PictureWriter::DrawAPicture");
		ConsoleDrawingLib::PictureWriter::DrawAPicture(gcnew System::String(path), x, y, width, heigth);
		Console::WriteLine("After call PictureWriter::DrawAPicture");
	}

	void __declspec(dllexport) DrawPicture(const wchar_t* path, int x, int y, int width, int heigth)
	{
		ConsoleDrawingLib::PictureWriter::DrawAPicture(gcnew System::String(path), x, y, width, heigth);
	}
}