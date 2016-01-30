/******************************************************************************\
* This is a Singleton class that emulates the axis input that nmost games have *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

/// <summary>

/// </summary>
public static class pxsLeapInput 
{	
	private enum HandID : int
	{
		Primary		= 0,
		Secondary	= 1
	};
	
	//Create a new leap controller object when you create this static class 
	static Leap.Controller 		m_controller	= null;
	static Leap.Frame			m_Frame			= null;
	static Leap.Hand			m_Hand			= null;
	static string Errors 			= "";
	static Vector normal=null;
	static Vector direction=null;
	
	// constructor called when the first class or member is referenced.
	static pxsLeapInput()
	{
		try
		{
			//Create a new leap controller object when you create this static class 
			m_controller	= new Leap.Controller();
		}
		catch 
		{
			Errors = Errors + '\r' + '\n'  + "Controller could not be created";
		}
	}

	public static Leap.Frame Frame
	{
		get { return m_Frame; }
	}
	
	public static Leap.Hand Hand
	{
		get { return m_Hand; }
	}
	
	public static void Update() 
	{	
		if( m_controller != null )
		{
			
			Frame lastFrame = m_Frame == null ? Frame.Invalid : m_Frame;
			m_Frame	= m_controller.Frame();
			if (m_Frame != null)
			{
				if (m_Frame.Hands.Count > 0)
				{
					m_Hand = m_Frame.Hands[0];
					normal = m_Hand.PalmNormal;
					direction = m_Hand.Direction;
				}
			}
		}
	}
	public static float GetRoll()
	{
		Update();
		float roll;
		roll=normal.Roll * 180.0f /3.1451f;
		return roll;
	}
	public static float GetPitch()
	{
		Update();
		float pitch;
		pitch=direction.Pitch * 180.0f /3.1451f;
		return pitch;
	}
	
	// returns the hand axis scaled from -1 to +1
	public static float GetHandAxis(string axisName)
	{
		float ret = GetHandAxisPrivate(axisName, true);
		return ret;
	}
	
	public static float GetHandAxisRaw(string axisName)
	{
		float ret = GetHandAxisPrivate(axisName, false);
		return ret;
	}
	private static float GetHandAxisPrivate(string axisName, bool scaled)
	{
		// Call Update so you can get the latest frame and hand
		Update();
		float ret = 0.0F;
		if (m_Hand != null)
		{
			Vector3 PalmPosition = new Vector3(0,0,0);
			Vector3 PalmNormal = new Vector3(0,0,0);
			Vector3 PalmDirection = new Vector3(0,0,0);
			if (scaled == true)
			{
				PalmPosition = m_Hand.PalmPosition.ToUnityTranslated();
				PalmNormal = m_Hand.PalmNormal.ToUnity();				
				PalmDirection = m_Hand.Direction.ToUnity();
			}
			else
			{
				PalmPosition = m_Hand.PalmPosition.ToUnity();
				PalmNormal = m_Hand.PalmPosition.ToUnity();
				PalmDirection = m_Hand.Direction.ToUnity();
			}
			switch (axisName)
			{
			case "Horizontal":
				ret = PalmPosition.x ;
				break;
			case "Vertical":
				ret = PalmPosition.y;
				break;
			case "Depth":
				ret = PalmPosition.z ;
				break;
			case "Rotation":
				ret = -2 * PalmNormal.x ;

				break;
			case "Tilt":
				ret = PalmNormal.z ;
				break;
			case "HorizontalDirection":
				ret = PalmDirection.x ;
				break;
			case "VericalDirection":
				ret = PalmDirection.y ;
				break;
			default:
				break;
			}
		}
		if (scaled == true)
				{
					if (ret > 1) {ret = 1;}
					if (ret < -1) {ret = -1;}
				}
		return ret;
	}
	
}
