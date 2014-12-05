using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class StoryScreen : MonoBehaviour {
	private string story;

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width*0.1f,Screen.height*0.1f,Screen.width-Screen.width*0.1f,Screen.height-Screen.height*0.1f));
		{
			GUILayout.BeginVertical();
			{
				GUILayout.Label ("Welcome to MAVERICK\n\n\n");
				GUILayout.Label("20th May 2020\nExactly at six o’clock in the morning Robert Teller is born in Liverpool at the Bankstown –Lidcombe Hospital.\n\n28th January 2032\nA boy named Maverick is born in New Babel, he is born prematurely but he will survive.\n\n21st June 2040\nRobert Teller gets his first doctorate being 20 years old in “Computer Sciences and Applied Robotics”.\n\n6th December 2040\nRobert Teller gets his first position at the “Robotic Science Corporation”.\n\n30th August 2041\nRobert Teller gets promoted to department manager.\n\n24th June 2050\nMaverick finishes school and enters acting school.\n\n1st November 2054\nRobert Teller has developed a new type of quantum computers, the first prototypes are flawed but promising. The Project “Innovative Quantum-Computer” is run by Robert Teller and has many subordinate departments.\n\n3rd January 2055\nRSC is announcing to launch a “thinking” and teachable computer until end 2060, rumours are that Aperture Science and Google have already ordered their first.\n\n2nd July 2055\nMaverick finishes acting school and due to lack of a better job begins to work in retail.\n\n14th February 2057\nThe tests at RSC are complete and the building of a first model starts.\n\n30th December 2058\nThe “Innovative Quantum-Computer 9000plus” is successfully built. The capacity of it exceeds every expectation; the IQ-C9000+ can coordinate every house robot in the entire city and thus increases their electiveness. RSC runs a test and gives control over every house robot in New Babel to the IQ-C9000+.\n\n7th January 2059\nStrange things are happening in New Babel. Headlines like “Mass Suicides” are repeatedly on the front pages of the local newspapers. There are daily reports of suicides.\n\nPresent\nMaverick thinks he has found a connection between the increasing numbers of house robots and the depression of the people in New Babel. He is visiting the RSC headquarter but there he is reassured that there cannot be a connection and that everything concerning the house robots is under control.\n\nLater Maverick is visited by Robert Teller who is asking him for help. He tells Maverick that he was right about the IQ-C9000+ being connected to the increasing cases of depression. The computer has found a way to absorb the “joy of life” through the house robots and it has become addicted to it so it always wants more.\nRobert Teller and Maverick are planning to save the city and Robert Teller knows how: he is going to build a device that can disconnect the IQ-C9000+ from the city’s network and thus stop it from gathering more “joy of life” from the people in it.");
				GUILayout.Label("Press any key to continue...");
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}

	/*
	void Start()
	{
		story = Load("/Text/StoryEN.txt");
	}
	*/
	void Update ()
	{
		if(Input.anyKey)
		{
			Application.LoadLevel(1);
		}
	}
	/*
	//aus: http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
	private string Load(string fileName)
	{
		try
		{
			string file = "";
			StreamReader theReader = new StreamReader(Application.dataPath+fileName, Encoding.Default);
			using (theReader)
			{
				string line;
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						file += line+"\n";
					}
				}
				while (line != null);
				theReader.Close();
				return file;
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("{0}\n", e.Message);
			return "Error";
		}
	}
	*/
}
