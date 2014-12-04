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

	void Update () {
		if(Input.anyKey)
		{
			Application.LoadLevel(1);
		}
	}

	//aus: http://answers.unity3d.com/questions/279750/loading-data-from-a-txt-file-c.html
	private string Load(string fileName)
	{
		// Handle any problems that might arise when reading the text
		try
		{
			string file = "";
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(Application.dataPath+fileName, Encoding.Default);
			
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
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
				// Done reading, close the reader and return true to broadcast success
				theReader.Close();
				return file;
			}
		}
		
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			Console.WriteLine("{0}\n", e.Message);
			return null;
		}
	}
}
