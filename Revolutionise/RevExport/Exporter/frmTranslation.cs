using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static Utilities.Transform;
using static Utilities.Extensions;

namespace MappingTool
{
    public partial class frmTranslation : Form
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

        private string _ExampleValue = "";
        public MethodType SelectedMethodType = MethodType.None;
        public string[] SelectedTransformParameters = { };
        public bool AllowInTransformEdits = false;

        #endregion

        #region Properties

        #endregion

        #region Constructors and Destructor

        public frmTranslation(string ExampleValue)
        {
            InitializeComponent();

            _ExampleValue = ExampleValue;
        }

        #endregion

        #region Event Handlers

        private void frmTranslation_Shown(object sender, EventArgs e)
        {
            UpdateTranslationOptions();

            lvwTransformationType.Items[0].Selected = true;
            lstCharacters.SelectedIndex = 3; // Comma
            cmbJoinCharacter.SelectedIndex = 3; // Comma

            TransformAndShowExampleValue(_ExampleValue);
        }

        private void lstEuroJudoTranslationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lstImportedColumnValues.Items.Count == 0)
            //{
            //    // Nothing selected
            //    lblExampleValue.Text = "[SELECT A TRANSFORMATION TYPE]";
            //}
            //else if (lstImportedColumnValues.SelectedItem == null)
            //{
            //    //lblExampleValue.Text = GetTransformedValue(lstImportedColumnValues.Items[0].ToString());
            //}
            //else
            //{
            //    //lblExampleValue.Text = GetTransformedValue(lstImportedColumnValues.SelectedItem.ToString());
            //}

            //EnableDisableSetButton();
        }

        private void radEuroJudoSimpleTranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (radEuroJudoValueTranslation.Checked)
            {
                UpdateTranslationOptions();
            }
        }

        private void radEuroJudoCharacterTranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (radEuroJudoCharacterTranslation.Checked)
            {
                UpdateTranslationOptions();
            }
        }

        private void radEuroJudoLengthTranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (radEuroJudoLengthTranslation.Checked)
            {
                UpdateTranslationOptions();
            }
        }

        private void radEuroJudoSubstringTranslation_CheckedChanged(object sender, EventArgs e)
        {
            if (radEuroJudoSubstringTranslation.Checked)
            {
                UpdateTranslationOptions();
            }
        }

        private void nudEuroJudoTransformCount_ValueChanged(object sender, EventArgs e)
        {
            TransformAndShowExampleValue(_ExampleValue);
        }

        private void nudEuroJudoTransformStart_ValueChanged(object sender, EventArgs e)
        {
            TransformAndShowExampleValue(_ExampleValue);
        }

        private void lvwTransformationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransformAndShowExampleValue(_ExampleValue);
        }

        private void lstCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransformAndShowExampleValue(_ExampleValue);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.AllowInTransformEdits = chkPerformValidation.Checked;
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        #endregion

        #region Private Methods

        private void UpdateTranslationOptions()
        {
            lvwTransformationType.Items.Clear();

            if (radEuroJudoValueTranslation.Checked)
            {
                lblEuroJudoTransformCharacter.Enabled = false;
                lstCharacters.Enabled = false;
                cmbJoinCharacter.Enabled = false;
                lblEuroJudoTransformCount.Enabled = false;
                nudEuroJudoTransformCount.Enabled = false;
                lblEuroJudoTransformStart.Enabled = false;
                nudEuroJudoTransformStart.Enabled = false;
                lvwTransformationType.Items.Add(new ListViewItem("None"));
                lvwTransformationType.Items.Add(new ListViewItem("Copy"));
                lvwTransformationType.Items.Add(new ListViewItem("Remove alpha characters"));
                lvwTransformationType.Items.Add(new ListViewItem("Remove numeric characters"));
                lvwTransformationType.Items.Add(new ListViewItem("Lowercase"));
                lvwTransformationType.Items.Add(new ListViewItem("Uppercase"));
                lvwTransformationType.Items.Add(new ListViewItem("Capitalise"));
                lvwTransformationType.Items.Add(new ListViewItem("Hash"));
            }
            else if (radEuroJudoCharacterTranslation.Checked)
            {
                lblEuroJudoTransformCharacter.Enabled = true;
                lstCharacters.Enabled = true;
                cmbJoinCharacter.Enabled = true;
                lblEuroJudoTransformCount.Enabled = false;
                nudEuroJudoTransformCount.Enabled = false;
                lblEuroJudoTransformStart.Enabled = false;
                nudEuroJudoTransformStart.Enabled = false;
                lvwTransformationType.Items.Add(new ListViewItem("Remove character"));
                lvwTransformationType.Items.Add(new ListViewItem("Remove left of character"));
                lvwTransformationType.Items.Add(new ListViewItem("Remove right of character"));
                lvwTransformationType.Items.Add(new ListViewItem("Switch left 2 values"));
                lvwTransformationType.Items.Add(new ListViewItem("Switch right 2 values"));
                lvwTransformationType.Items.Add(new ListViewItem("Switch left and right values"));
                lvwTransformationType.Items.Add(new ListViewItem("First value"));
                lvwTransformationType.Items.Add(new ListViewItem("Second value"));
                lvwTransformationType.Items.Add(new ListViewItem("Third value"));
                lvwTransformationType.Items.Add(new ListViewItem("Left 2 values"));
                lvwTransformationType.Items.Add(new ListViewItem("Right 2 values"));
            }
            else if (radEuroJudoLengthTranslation.Checked)
            {
                lblEuroJudoTransformCharacter.Enabled = false;
                lstCharacters.Enabled = false;
                cmbJoinCharacter.Enabled = false;
                lblEuroJudoTransformCount.Enabled = true;
                nudEuroJudoTransformCount.Enabled = true;
                lblEuroJudoTransformStart.Enabled = false;
                nudEuroJudoTransformStart.Enabled = false;
                lvwTransformationType.Items.Add(new ListViewItem("Remove left characters"));
                lvwTransformationType.Items.Add(new ListViewItem("Remove right characters"));
            }
            else if (radEuroJudoSubstringTranslation.Checked)
            {
                lblEuroJudoTransformCharacter.Enabled = false;
                lstCharacters.Enabled = false;
                cmbJoinCharacter.Enabled = false;
                lblEuroJudoTransformCount.Enabled = true;
                nudEuroJudoTransformCount.Enabled = true;
                lblEuroJudoTransformStart.Enabled = true;
                nudEuroJudoTransformStart.Enabled = true;
                lvwTransformationType.Items.Add(new ListViewItem("Remove characters"));
                lvwTransformationType.Items.Add(new ListViewItem("Extract characters"));
            }
        }

        private void TransformAndShowExampleValue(string SelectedValue)
        {
            int SelectedIndex = -1;
            string[] SplitCharacters = { };
            string JoinCharacter = "";
            int Count = 0;
            int Start = 0;

            if (lvwTransformationType.SelectedItems.Count == 0) // || lstImportedColumnValues.Items.Count == 0)
            {
                return;
            }

            SelectedIndex = lvwTransformationType.SelectedItems[0].Index;
            SplitCharacters = lstCharacters.SelectedItems.ToList<string>().ToArray();
            JoinCharacter = cmbJoinCharacter.Text;
            Count = (int)nudEuroJudoTransformCount.Value;
            Start = (int)nudEuroJudoTransformStart.Value;

            if (radEuroJudoValueTranslation.Checked)
            {
                lblExampleValue.Text = GetTransformedValue(SelectedValue, SelectedIndex);
            }
            else if (radEuroJudoCharacterTranslation.Checked)
            {
                lblExampleValue.Text = GetTransformedValue(SelectedValue, SelectedIndex, SplitCharacters, JoinCharacter);
            }
            else if (radEuroJudoLengthTranslation.Checked)
            {
                lblExampleValue.Text = GetTransformedValue(SelectedValue, SelectedIndex, Count);
            }
            else if (radEuroJudoSubstringTranslation.Checked)
            {
                lblExampleValue.Text = GetTransformedValue(SelectedValue, SelectedIndex, Start, Count);
            }
        }

        public string GetTransformedValue(string Value, MethodType TransformMethodType, string[] Parameters)
        {
            string Result = "";
            int SelectedIndex = -1;

            SelectedIndex = lvwTransformationType.SelectedItems[0].Index;

            switch (Parameters.Length)
            {
                case 0: // Simple
                    Result = GetTransformedValue(Value, SelectedIndex);
                    break;
                case 1: // Character and Length
                    {
                        string[] SplitParams = Parameters.Take(Parameters.Length - 1).ToArray<string>();
                        string JoinParam = Parameters[Parameters.Length - 1];

                        if (Enum.GetName(typeof(Transform.MethodType), TransformMethodType).StartsWith("Char"))
                        {
                            Result = GetTransformedValue(Value, SelectedIndex, SplitParams, JoinParam);
                        }
                        else
                        {
                            Result = GetTransformedValue(Value, SelectedIndex, Convert.ToInt32(Parameters[0]));
                        }
                        break;
                    }
                case 2: // Substring
                    Result = GetTransformedValue(Value, SelectedIndex, Convert.ToInt32(Parameters[0]), Convert.ToInt32(Parameters[1]));
                    break;
            }

            return Result;
        }

        private string GetTransformedValue(string Value, int SelectedTransformIndex) // Value
        {
            string Result = "";

            switch (SelectedTransformIndex)
            {
                case 0: // MethodType.None:
                    Result = "";
                    SelectedMethodType = MethodType.None;
                    SelectedTransformParameters = null;
                    break;
                case 1: // MethodType.Value_Copy:
                    Result = Value;
                    SelectedMethodType = MethodType.Value_Copy;
                    SelectedTransformParameters = null;
                    break;
                case 2: // MethodType.Value_RemoveAlphaChars:
                    Result = Transform.Execute(Value, Transform.ValueMethod.RemoveAlphaChars);
                    SelectedMethodType = MethodType.Value_RemoveAlphaChars;
                    SelectedTransformParameters = null;
                    break;
                case 3: // MethodType.Value_RemoveNumericChars:
                    Result = Transform.Execute(Value, Transform.ValueMethod.RemoveNumericChars);
                    SelectedMethodType = MethodType.Value_RemoveNumericChars;
                    SelectedTransformParameters = null;
                    break;
                case 4: // MethodType.Value_Lowercase:
                    Result = Transform.Execute(Value, Transform.ValueMethod.Lowercase);
                    SelectedMethodType = MethodType.Value_Lowercase;
                    SelectedTransformParameters = null;
                    break;
                case 5: // MethodType.Value_Uppercase:
                    Result = Transform.Execute(Value, Transform.ValueMethod.Uppercase);
                    SelectedMethodType = MethodType.Value_Uppercase;
                    SelectedTransformParameters = null;
                    break;
                case 6: // MethodType.Value_Capitalise:
                    Result = Transform.Execute(Value, Transform.ValueMethod.Capitalise);
                    SelectedMethodType = MethodType.Value_Capitalise;
                    SelectedTransformParameters = null;
                    break;
                case 7: // MethodType.Value_Hash
                    Result = Transform.Execute(Value, Transform.ValueMethod.Hash);
                    SelectedMethodType = MethodType.Value_Hash;
                    SelectedTransformParameters = null;
                    break;
            }

            return Result;
        }

        private string GetTransformedValue(string Value, int SelectedTransformIndex, string[] SplitCharacters, string JoinCharacter) // Character
        {
            string Result = "";
            List<string> Params = new List<string>();

            switch (SelectedTransformIndex)
            {
                case 0: // MethodType.Character_RemoveChar:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.RemoveChar, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_RemoveChar;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 1: // Transform.MethodType.Character_LeftOfChar:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.LeftOfChar, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_LeftOfChar;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 2: // Transform.MethodType.Character_RightOfChar:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.RightOfChar, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_RightOfChar;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 3: // Transform.MethodType.Character_SwitchLeftTwoValues:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.SwitchLeftTwoValues, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_SwitchLeftTwoValues;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 4: // Transform.MethodType.Character_SwitchRightTwoValues:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.SwitchRightTwoValues, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_SwitchRightTwoValues;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 5: // Transform.MethodType.Character_SwitchLeftAndRightValues:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.SwitchLeftAndRightValues, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_SwitchLeftAndRightValues;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 6: // Transform.MethodType.Character_FirstValue:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.FirstValue, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_FirstValue;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 7: // Transform.MethodType.Character_SecondValue:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.SecondValue, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_SecondValue;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 8: // Transform.MethodType.Character_ThirdValue:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.ThirdValue, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_ThirdValue;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 9: // Transform.MethodType.Character_LeftTwoValues:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.LeftTwoValues, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_LeftTwoValues;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 10: // Transform.MethodType.Character_RightTwoValues:
                    Result = Transform.Execute(Value, Transform.CharacterMethod.RightTwoValues, SplitCharacters, JoinCharacter);
                    SelectedMethodType = MethodType.Character_RightTwoValues;
                    Params.AddRange(SplitCharacters);
                    Params.Add(JoinCharacter);
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
            }

            return Result;
        }

        private string GetTransformedValue(string Value, int SelectedTransformIndex, int Count) // Length
        {
            string Result = "";
            List<string> Params = new List<string>();

            switch (SelectedTransformIndex)
            {
                case 0: // MethodType.Length_RemoveLeftChars:
                    Result = Transform.Execute(Value, Transform.LengthMethod.RemoveLeftChars, Count);
                    SelectedMethodType = MethodType.Length_RemoveLeftChars;
                    Params.Add(SelectedTransformIndex.ToString());
                    Params.Add(Count.ToString());
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 1: // MethodType.Length_RemoveRightChars:
                    Result = Transform.Execute(Value, Transform.LengthMethod.RemoveRightChars, Count);
                    SelectedMethodType = MethodType.Length_RemoveRightChars;
                    Params.Add(SelectedTransformIndex.ToString());
                    Params.Add(Count.ToString());
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
            }


            return Result;
        }

        private string GetTransformedValue(string Value, int SelectedTransformIndex, int Start, int Count) // Substring
        {
            string Result = "";
            List<string> Params = new List<string>();

            switch (SelectedTransformIndex)
            {
                case 0: // MethodType.Substring_ExtractChars:
                    Result = Transform.Execute(Value, Transform.SubstringMethod.ExtractChars, Start, Count);
                    SelectedMethodType = MethodType.Substring_ExtractChars;
                    Params.Add(SelectedTransformIndex.ToString());
                    Params.Add(Start.ToString());
                    Params.Add(Count.ToString());
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
                case 1: // MethodType.Length_RemoveRightChars:
                    Result = Transform.Execute(Value, Transform.SubstringMethod.RemoveChars, Start, Count);
                    SelectedMethodType = MethodType.Substring_RemoveChars;
                    Params.Add(SelectedTransformIndex.ToString());
                    Params.Add(Start.ToString());
                    Params.Add(Count.ToString());
                    SelectedTransformParameters = Params.ToArray<string>();
                    break;
            }

            return Result;
        }

        #endregion

        #region Public Methods

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion

    }
}
