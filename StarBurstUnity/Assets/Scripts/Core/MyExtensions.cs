using UnityEngine;
using System.Collections;

public static class MyExtensions
{
	static public Color Alphaed( this Color c, float a )
	{
		Color result = c;
		result.a = a;
		return result;
	}

	/*
	static public string DebugDescribe<T>( this T t) where T : IDebugDescribable
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder ();
		t.DebugDescribe (sb);
		return sb.ToString ();
	}*/
}
