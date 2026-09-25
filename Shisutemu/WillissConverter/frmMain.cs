using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using Microsoft.VisualBasic.FileIO;
using static Utilities.Extensions;

namespace WillissConverter
{
	public partial class frmMain : Form
	{
		#region Constants

		#endregion

		#region Delegates

		#endregion

		#region Events

		#endregion

		#region Enums

		#endregion

		#region DLL Imports

		#endregion

		#region Fields

		private string _Filename = "";
		private TextFieldParser _DataRow = null;
		private string[] _Entrants = null;
		private string[] _FileData = null;
		private int _RowCounter = 0;
		private Tournament _Tournament = null;

		#endregion

		#region Properties

		#endregion

		#region Constructors and Destructor

		public frmMain()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void btnRead_Click(object sender, EventArgs e)
		{
			int lineCounter = 0;

			System.Collections.ObjectModel.Collection<string> v = new System.Collections.ObjectModel.Collection<string>(Enumerable.Range(1, 40).Select(i => i.ToString()).ToArray());

			_FileData = _DataRow.ReadFields();

			int MaximumAge = _FileData.Length;

			foreach (string entrant in _Entrants)
			{
				string[] personData; // = entrant.Split(',');
				TextFieldParser parser = new TextFieldParser(new StringReader(entrant));

				parser.HasFieldsEnclosedInQuotes = true;
				parser.SetDelimiters(",");

				personData = parser.ReadFields();

				if (chkIgnoreFirstRow.Checked && lineCounter == 0)
				{
					// First row, and we ignore it
				}
				else
				{
					// Ok to read

				}

				lineCounter++;
			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			if (chkIgnoreFirstRow.Checked)
			{
				txtRowCounter.Text = "2";
			}
		}

		private void nudLastName_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudFirstName_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudAge_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudWeight_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudGender_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudRank_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudTelephone_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudEmail_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudNotes_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void nudClub_ValueChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void chkIgnoreFirstRow_CheckedChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void chkCalculate_CheckedChanged(object sender, EventArgs e)
		{
			ShowFileData();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();

			DialogResult result = dialog.ShowDialog();

			if (result == DialogResult.OK && dialog.FileName.Length > 0)
			{
				_Filename = dialog.FileName;
				txtFilename.Text = _Filename;
				txtOutputFile.Text = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(_Filename), "Output.csv");

				_RowCounter = 0;
				txtRowCounter.Text = "1";

				if (chkIgnoreFirstRow.Checked)
				{
					_RowCounter = 1;
					txtRowCounter.Text = "2";
				}

				_Entrants = System.IO.File.ReadAllLines(_Filename);

				lblEntrantCount.Text = _Entrants.Length + " entrants in file";

				//btnLoad.Enabled = true;

				ShowFileData();

				grpColumns.Enabled = true;
			}
		}

		private void btnLeft_Click(object sender, EventArgs e)
		{
			_RowCounter--;

			if (_RowCounter < 0)
			{
				_RowCounter = 0;
			}

			ShowFileData();

			txtRowCounter.Text = (_RowCounter + 1).ToString();
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			_RowCounter++;

			if (_RowCounter > _Entrants.Length - 1)
			{
				_RowCounter = _Entrants.Length - 1;
			}

			ShowFileData();

			txtRowCounter.Text = (_RowCounter + 1).ToString();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(txtOutputFile.Text))
			{
				System.IO.File.Delete(txtOutputFile.Text);
			}

			using (StreamWriter writer = System.IO.File.CreateText(txtOutputFile.Text))
			{

				for (_RowCounter = 0; _RowCounter < _Entrants.Length; _RowCounter++)
				{
					ShowFileData();

					txtRowCounter.Text = (_RowCounter + 1).ToString();

					StringBuilder output = new StringBuilder();

					output.Append(txtLastName.Text.Replace(",",""));
					output.Append(",");
					output.Append(txtFirstName.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtAge.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtWeight.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtGender.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtRank.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtTelephone.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtEmail.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtNotes.Text.Replace(",", ""));
					output.Append(",");
					output.Append(txtClub.Text.Replace(",", ""));

					writer.WriteLine(output.ToString());

				}

				writer.Close();
			}
		}

		#endregion

		#region Private Methods

		private void ShowFileData()
		{
			_DataRow = new TextFieldParser(new StringReader(_Entrants[_RowCounter]));

			_DataRow.HasFieldsEnclosedInQuotes = true;
			_DataRow.SetDelimiters(",");

			_FileData = _DataRow.ReadFields();

			nudAge.Maximum = _FileData.Length;
			nudClub.Maximum = _FileData.Length;
			nudEmail.Maximum = _FileData.Length;
			nudFirstName.Maximum = _FileData.Length;
			nudGender.Maximum = _FileData.Length;
			nudLastName.Maximum = _FileData.Length;
			nudNotes.Maximum = _FileData.Length;
			nudTelephone.Maximum = _FileData.Length;
			nudWeight.Maximum = _FileData.Length;

			if (chkIgnoreFirstRow.Checked)
			{
				_DataRow.ReadFields();
			}

			txtLastName.Text = _FileData[(int)nudLastName.Value - 1].ToLower().Capitalise().Replace(",", "");

			if (txtLastName.Text.EndsWith("."))
			{
				txtLastName.Text = txtLastName.Text.Remove(txtLastName.Text.Length - 1);
			}
			txtFirstName.Text = _FileData[(int)nudFirstName.Value - 1].ToLower().Capitalise().Replace(",", "");

			if (chkCalculate.Checked)
			{
				try
				{
					DateTime birthDate = DateTime.MinValue;
					DateTime.TryParse(_FileData[(int)nudAge.Value - 1].RemoveAlphaCharacters().Replace(",", ""), out birthDate);

					txtAge.Text = birthDate.Age().ToString().Replace(",", "");
				}
				catch
				{
				}
			}
			else
			{
				txtAge.Text = _FileData[(int)nudAge.Value - 1].RemoveAlphaCharacters();
			}

			txtWeight.Text = _FileData[(int)nudWeight.Value - 1].RemoveAlphaCharacters().Replace(",", "");
			txtGender.Text = _FileData[(int)nudGender.Value - 1].Capitalise().Replace(",", "");
			txtRank.Text = _FileData[(int)nudRank.Value - 1].Capitalise().Replace(",", "");
			txtTelephone.Text = _FileData[(int)nudTelephone.Value - 1].Replace(" ", "").RemoveAlphaCharacters().Replace(",", "");
			txtEmail.Text = _FileData[(int)nudEmail.Value - 1].Replace(" ", "").Replace(",", "");
			txtNotes.Text = _FileData[(int)nudNotes.Value - 1].Replace(",", "");
			txtClub.Text = _FileData[(int)nudClub.Value - 1].Capitalise().Replace(",", "");
		}

		#endregion

		#region Public Methods

		#endregion

		#region Classes

		// By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

		#endregion

		private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabMain.SelectedIndex == 1)
			{
				_Tournament = new Tournament(new DateTime(2017, 01, 01), new DateTime(2017, 01, 02), "Rockingham");

				_Tournament.SetMatCount(3);
				_Tournament.LoadCategories(@"C:\Users\YourUser\Documents\Visual Studio 2017\Projects\Shisutemu\Data\Categories.xml");

				//_Tournament.LoadEntrantsFromFile(txtFilename.Text);

				_Tournament.DistributeWeightCategoriesAmongstMats(true);

				//foreach (AgeCategory a in _Tournament.AgeCategories)
				//{
				//	Console.WriteLine("<AgeCategory>");
				//	Console.WriteLine("    <Name>" + a + "</Name>");

				//	if (a.MinimumAge > 0)
				//	{
				//		Console.WriteLine("    <MinAge>" + a.MinimumAge + "</MinAge>");
				//	}
				//	else
				//	{
				//		Console.WriteLine("    <MinAge>0</MinAge>");
				//	}

				//	if (a.MaximumAge > 0)
				//	{
				//		Console.WriteLine("    <MaxAge>" + a.MaximumAge + "</MaxAge>");
				//	}
				//	else
				//	{
				//		Console.WriteLine("    <MaxAge>99</MaxAge>");
				//	}

				//	Console.WriteLine("</AgeCategory>");
				//}

				foreach (WeightCategory a in _Tournament.WeightCategories)
				{
					Console.WriteLine("<Division>");
					Console.WriteLine("    <ID>" + Guid.NewGuid() + "</ID>");
					Console.WriteLine("    <Description>" + a + "</Description>");
					Console.WriteLine("    <GenderStr>" + a.Sex + "</GenderStr>");
					Console.WriteLine("    <RankGeneralNum>1</RankGeneralNum>");
					Console.WriteLine("    <AgeGroup>" + a.AgeCategory.Name + "</AgeGroup>");

					if (a.AgeCategory.MinimumAge > 0)
					{
						Console.WriteLine("    <MinAge>" + a.AgeCategory.MinimumAge + "</MinAge>");
					}
					else
					{
						Console.WriteLine("    <MinAge>0</MinAge>");
					}

					if (a.AgeCategory.MaximumAge > 0)
					{
						Console.WriteLine("    <MaxAge>" + a.AgeCategory.MaximumAge + "</MaxAge>");
					}
					else
					{
						Console.WriteLine("    <MaxAge>99</MaxAge>");
					}

					Console.WriteLine("    <WeightClass>" + a.AgeCategory.Name + "</WeightClass>");
					Console.WriteLine("    <MinWeight>" + a.LowerWeightLimit + "</MinWeight>");

					if (a.UpperWeightLimit > 0)
					{
						Console.WriteLine("    <MaxWeight>" + a.UpperWeightLimit + "</MaxWeight>");
					}
					else
					{
						Console.WriteLine("    <MaxWeight>999</MaxWeight>");
					}

					Console.WriteLine("    <BracketType>0</BracketType>");
					Console.WriteLine("    <RequestedBracketType>0</RequestedBracketType>");
					Console.WriteLine("    <MatNumber>" + "0" + "</MatNumber>");
					Console.WriteLine("    <ScoringSystem>0</ScoringSystem>");
					Console.WriteLine("    <CompetitorsAreTeams>0</CompetitorsAreTeams>");
					Console.WriteLine("    <RulesName>JudoTimer.Messaging.RulesJudoIJF2017_Modified, JudoTimer.Messaging, Version=1.1.0.1, Culture=neutral, PublicKeyToken=null</RulesName>");
					Console.WriteLine("    <NoGi>false</NoGi>");
					Console.WriteLine("</Division>");
				}

				// Now go through each weight category and write them to the XML file
			}
		}
	}
}
