using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System;

public class StoryScreen : MonoBehaviour {

	void OnGUI()
	{
		GUI.Label (new Rect(20,20,Screen.width-20,40), "Welcome to Maverick");
		string story = Load("/Text/StoryEN.txt");
		GUI.TextArea(new Rect(20,60,Screen.width-20,605),story);
		GUI.Label (new Rect(20,685,Screen.width-20,40), "Press any key to continue...");
	}

	void Update ()
	{
		if(Input.anyKey)
		{
			Application.LoadLevel(1);
		}
	}

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
			return null;
		}
	}
}
