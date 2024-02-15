using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Heroes3Editor.Models;

namespace Heroes3Editor
{
    /// <summary>
    /// Interaction logic for HeroPanel.xaml
    /// </summary>
    public partial class HeroPanel : UserControl
    {
        private Hero _hero;

        public Hero Hero
        {
            set
            {
                _hero = value;
                if (_hero.IsHOTAGame)
                {
                    SetHOTASettings();
                }
                else
                {
                    SetClassicSettings();
                }

                var txtBoxExperience = FindName("Experience") as TextBox;
                txtBoxExperience.Text = _hero.Experience.ToString();

                var txtBoxCoordinatesXMarker = FindName("CoordinatesXMarker") as TextBox;
                var txtBoxCoordinatesYMarker = FindName("CoordinatesYMarker") as TextBox;

                //if (_hero.CoordinatesXMarker == -1 && _hero.CoordinatesYMarker == -1) //marker without coordinates
                //{
                //    txtBoxCoordinatesXMarker.IsEnabled = false;
                //    txtBoxCoordinatesYMarker.IsEnabled = false;
                //}
                //else
                //{
                txtBoxCoordinatesXMarker.Text = _hero.CoordinatesXMarker.ToString();
                txtBoxCoordinatesYMarker.Text = _hero.CoordinatesYMarker.ToString();
                //}

                var txtBoxCurrentMovementPoints = FindName("CurrentMovementPoints") as TextBox;
                txtBoxCurrentMovementPoints.Text = _hero.CurrentMovementPoints.ToString();

                var txtBoxMaxMovementPoints = FindName("MaxMovementPoints") as TextBox;
                txtBoxMaxMovementPoints.Text = _hero.MaxMovementPoints.ToString();


                var txtBoxHeroLevel = FindName("HeroLevel") as TextBox;
                txtBoxHeroLevel.Text = _hero.HeroLevel.ToString();

                var txtBoxManaPoints = FindName("ManaPoints") as TextBox;
                txtBoxManaPoints.Text = _hero.ManaPoints.ToString();

                var txtBoxCoordinatesX = FindName("CoordinatesX") as TextBox;
                var txtBoxCoordinatesY = FindName("CoordinatesY") as TextBox;
                var txtBoxCoordinatesZ = FindName("CoordinatesZ") as TextBox;

                if (_hero.CoordinatesX == -1 && _hero.CoordinatesY == -1 && _hero.CoordinatesZ == 255) //hero without coordinates
                {
                    txtBoxCoordinatesX.IsEnabled = false;
                    txtBoxCoordinatesY.IsEnabled = false;
                    txtBoxCoordinatesZ.IsEnabled = false;
                }
                else
                {
                    txtBoxCoordinatesX.Text = _hero.CoordinatesX.ToString();
                    txtBoxCoordinatesY.Text = _hero.CoordinatesY.ToString();
                    txtBoxCoordinatesZ.Text = _hero.CoordinatesZ.ToString();
                }

                for (int i = 0; i < 4; ++i)
                {
                    var txtBox = FindName("Attribute" + i) as TextBox;
                    txtBox.Text = _hero.Attributes[i].ToString();
                }

                for (int i = 0; i < 8; ++i)
                {
                    var cboBox = FindName("Skill" + i) as ComboBox;
                    var txtBox = FindName("SkillLevel" + i) as TextBox;
                    if (i < _hero.NumOfSkills)
                    {
                        cboBox.SelectedItem = _hero.Skills[i];
                        txtBox.Text = _hero.SkillLevels[i].ToString();
                    }
                    else if (i > _hero.NumOfSkills)
                    {
                        cboBox.IsEnabled = false;
                        txtBox.IsEnabled = false;
                    }
                    else
                    {
                        txtBox.IsEnabled = false;
                    }
                }

                foreach (var spell in _hero.Spells)
                {
                    var chkBox = FindName(spell) as CheckBox;
                    chkBox.IsChecked = true;
                }

                for (int i = 0; i < 7; ++i)
                {
                    var cboBox = FindName("Creature" + i) as ComboBox;
                    var txtBox = FindName("CreatureAmount" + i) as TextBox;
                    if (_hero.Creatures[i] != null)
                    {
                        cboBox.SelectedItem = _hero.Creatures[i];
                        txtBox.Text = _hero.CreatureAmounts[i].ToString();
                    }
                    else
                    {
                        txtBox.IsEnabled = false;
                    }
                }

                foreach (var warMachine in _hero.WarMachines)
                {
                    var toggleComponent = FindName(warMachine) as ToggleButton;
                    toggleComponent.IsChecked = true;
                }

                var toggleSpellBook = FindName("SpellBook") as ToggleButton;
                toggleSpellBook.IsChecked = _hero.SpellBookState;

                var toggleCatapult = FindName("Catapult") as ToggleButton;
                toggleCatapult.IsChecked = _hero.CatapultState;


                var gears = new List<string>(_hero.EquippedArtifacts.Keys);
                foreach (var gear in gears)
                {
                    // Attach an EA_ prefix to gear because there's already
                    // a CheckBox for the spell Shield
                    var cboBox = FindName("EA_" + gear) as ComboBox;
                    cboBox.SelectedItem = _hero.EquippedArtifacts[gear];
                }
            }
        }

        public HeroPanel()
        {
            InitializeComponent();
        }

        private void SetHOTASettings()
        {
            SetComponentVisibility("Ballista", Visibility.Hidden);
            SetComponentVisibility("BallistaRadio", Visibility.Visible);
            SetComponentVisibility("Canon", Visibility.Visible);
        }
        private void SetClassicSettings()
        {
            SetComponentVisibility("Ballista", Visibility.Visible);
            SetComponentVisibility("BallistaRadio", Visibility.Hidden);
            SetComponentVisibility("Canon", Visibility.Hidden);
        }
        private void SetComponentVisibility(string name, Visibility visibility)
        {
            var component = FindName(name) as ButtonBase;
            if (component != null)
            {
                component.Visibility = visibility;
            }
        }
        private void UpdateExperience(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            int value;
            bool isNumber = int.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 2147483647) return;

            _hero.UpdateExperience(4, value);
        }

        private void UpdateCoordinatesXMarker(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            int value;
            bool isNumber = int.TryParse(txtBox.Text, out value);
            if (!isNumber || value < -1 || value > 2147483647) return;

            _hero.UpdateCoordinatesXMarker(4, value);
        }

        private void UpdateCoordinatesYMarker(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            int value;
            bool isNumber = int.TryParse(txtBox.Text, out value);
            if (!isNumber || value < -1 || value > 2147483647) return;

            _hero.UpdateCoordinatesYMarker(4, value);
        }

        private void UpdateCurrentMovementPoints(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            int value;
            bool isNumber = int.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 1000000) return;

            _hero.UpdateCurrentMovementPoints(4, value);
        }

        private void UpdateMaxMovementPoints(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            int value;
            bool isNumber = int.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 1000000) return;

            _hero.UpdateMaxMovementPoints(4, value);
        }

        private void UpdateHeroLevel(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            byte value;
            bool isNumber = byte.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 255) return;

            _hero.UpdateHeroLevel(value);
        }

        private void UpdateManaPoints(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            short value;
            bool isNumber = short.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 9999) return;

            _hero.UpdateManaPoints(2, value);
        }

        private void UpdateCoordinatesX(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            short value;
            bool isNumber = short.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 32767) return;

            _hero.UpdateCoordinatesX(2, value);
        }
        private void UpdateCoordinatesY(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            short value;
            bool isNumber = short.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 32767) return;

            _hero.UpdateCoordinatesY(2, value);
        }
        private void UpdateCoordinatesZ(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            byte value;
            bool isNumber = byte.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 1) return;

            _hero.UpdateCoordinatesZ(value);
        }

        private void UpdateAttribute(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;

            byte value;
            bool isNumber = byte.TryParse(txtBox.Text, out value);
            if (!isNumber || value < 0 || value > 99) return;

            var i = int.Parse(txtBox.Name.Substring("Attribute".Length));
            _hero.UpdateAttribute(i, value);
        }

        private void UpdateSkill(object sender, RoutedEventArgs e)
        {
            var cboBox = e.Source as ComboBox;
            var slot = int.Parse(cboBox.Name.Substring("Skill".Length));
            var skill = cboBox.SelectedItem as string;

            var oldNumOfSkills = _hero.NumOfSkills;
            _hero.UpdateSkill(slot, skill);

            if (_hero.NumOfSkills > oldNumOfSkills)
            {
                var txtBox = FindName("SkillLevel" + slot) as TextBox;
                txtBox.Text = _hero.SkillLevels[slot].ToString();
                txtBox.IsEnabled = true;

                if (_hero.NumOfSkills < 8)
                {
                    var nextCboBox = FindName("Skill" + _hero.NumOfSkills) as ComboBox;
                    nextCboBox.IsEnabled = true;
                }
            }
        }

        private void UpdateSkillLevel(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;
            var slot = int.Parse(txtBox.Name.Substring("SkillLevel".Length));

            byte level;
            bool isNumber = byte.TryParse(txtBox.Text, out level);
            if (!isNumber || level < 0 || level > 3) return;

            _hero.UpdateSkillLevel(slot, level);
        }

        private void AddSpell(object sender, RoutedEventArgs e)
        {
            var chkBox = e.Source as CheckBox;
            _hero.AddSpell(chkBox.Name);
        }

        private void RemoveSpell(object sender, RoutedEventArgs e)
        {
            var chkBox = e.Source as CheckBox;
            _hero.RemoveSpell(chkBox.Name);
        }

        private void AddSpellBook(object sender, RoutedEventArgs e)
        {
            _hero.AddSpellBook();
        }

        private void RemoveSpellBook(object sender, RoutedEventArgs e)
        {
            _hero.RemoveSpellBook();
        }

        private void AddCatapult(object sender, RoutedEventArgs e)
        {
            _hero.AddCatapult();
        }

        private void RemoveCatapult(object sender, RoutedEventArgs e)
        {
            _hero.RemoveCatapult();
        }

        private void UpdateCreature(object sender, RoutedEventArgs e)
        {
            var cboBox = e.Source as ComboBox;
            var i = int.Parse(cboBox.Name.Substring("Creature".Length));
            var creature = cboBox.SelectedItem as string;

            _hero.UpdateCreature(i, creature);
            var txtBox = FindName("CreatureAmount" + i) as TextBox;
            if (!txtBox.IsEnabled)
            {
                txtBox.Text = _hero.CreatureAmounts[i].ToString();
                txtBox.IsEnabled = true;
            }
        }

        private void UpdateCreatureAmount(object sender, RoutedEventArgs e)
        {
            var txtBox = e.Source as TextBox;
            var i = int.Parse(txtBox.Name.Substring("CreatureAmount".Length));

            int amount;
            bool isNumber = int.TryParse(txtBox.Text, out amount);
            if (!isNumber || amount < 0 || amount > 9999) return;

            _hero.UpdateCreatureAmount(i, amount);
        }

        private void AddWarMachine(object sender, RoutedEventArgs e)
        {
            var component = e.Source as ButtonBase;
            if (component == null)
            {
                return;
            }
            _hero.AddWarMachine(component.Tag.ToString());
        }

        private void RemoveWarMachine(object sender, RoutedEventArgs e)
        {
            var component = e.Source as ButtonBase;
            _hero.RemoveWarMachine(component.Tag.ToString());
        }

        private void UpdateEquippedArtifact(object sender, RoutedEventArgs e)
        {
            var cboBox = e.Source as ComboBox;
            var gear = cboBox.Name.Substring("EA_".Length);
            var artifact = cboBox.SelectedItem as string;

            _hero.UpdateEquippedArtifact(gear, artifact);
        }

        private void UpdateArtifactInfo(object sender, RoutedEventArgs e)
        {
            var cboBox = e.Source as ComboBox;
            var artifact = cboBox.SelectedItem as string;

            if (null != _hero.UpdateArtifactInfo(artifact))
            {
                var txtBlock = FindName("Attack") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[1];

                txtBlock = FindName("Defense") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[2];

                txtBlock = FindName("Power") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[3];

                txtBlock = FindName("Knowledge") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[4];

                txtBlock = FindName("Morale") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[5];

                txtBlock = FindName("Luck") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[6];

                txtBlock = FindName("Effects") as TextBlock;
                txtBlock.Text = _hero.UpdateArtifactInfo(artifact)[7];
            }
        }

        private void ClearArtifactInfo(object sender, RoutedEventArgs e)
        {
            var txtBlock = FindName("Attack") as TextBlock;
            txtBlock.Text = "";
            txtBlock = FindName("Defense") as TextBlock;
            txtBlock.Text = "";
            txtBlock = FindName("Power") as TextBlock;
            txtBlock.Text = "";
            txtBlock = FindName("Knowledge") as TextBlock;
            txtBlock.Text = "";
            txtBlock = FindName("Morale") as TextBlock;
            txtBlock.Text = "";
            txtBlock = FindName("Luck") as TextBlock;
            txtBlock.Text = "";
            txtBlock = FindName("Effects") as TextBlock;
            txtBlock.Text = "";
        }
    }
}
