using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using KabanovExam.Models;

namespace KabanovExam
{
    public partial class AddEditPartner : Window
    {
        private Partner _partner;
        private bool _isEditMode;

        public AddEditPartner(Partner partner = null)
        {
            InitializeComponent();

            using (var context = new KabanovExamContext())
            {
                PartnerTypeComboBox.ItemsSource = context.PartnersTypes.ToList();
                PartnerTypeComboBox.DisplayMemberPath = "TipPartnera";
                PartnerTypeComboBox.SelectedValuePath = "PartnersType_ID";
            }

            if (partner != null)
            {
                _isEditMode = true;
                _partner = partner;
                LoadPartnerData(partner);
            }
            else
            {
                _isEditMode = false;
                _partner = new Partner();
            }
        }

        private void LoadPartnerData(Partner partner)
        {
            NaimenovaniePartnera.Text = partner.NaimenovaniePartnera;
            PartnerTypeComboBox.SelectedValue = partner.PartnersType_ID;
            Familiya.Text = partner.Familiya;
            Imya.Text = partner.Imya;
            Otchestvo.Text = partner.Otchestvo;
            Telephone.Text = partner.Telephone;
            Email.Text = partner.Email;
            Index.Text = partner.Index;
            Oblast.Text = partner.Oblast;
            Gorod.Text = partner.Gorod;
            Ulica.Text = partner.Ulica;
            Dom.Text = partner.Dom.ToString();
            Reyting.Text = partner.Reyting.ToString();
            INN.Text = partner.INN;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NaimenovaniePartnera.Text))
            {
                MessageBox.Show("Поле Наименование партнёра должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Familiya.Text))
            {
                MessageBox.Show("Поле Фамилия должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Imya.Text))
            {
                MessageBox.Show("Поле Имя должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Otchestvo.Text))
            {
                MessageBox.Show("Поле Отчество должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Telephone.Text))
            {
                MessageBox.Show("Поле Телефон должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Email.Text))
            {
                MessageBox.Show("Поле Электронная почта должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(INN.Text))
            {
                MessageBox.Show("Поле ИНН должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (INN.Text.Length != 10)
            {
                MessageBox.Show("Введите правильно ИНН.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Index.Text))
            {
                MessageBox.Show("Поле Индекс должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Index.Text.Length != 6)
            {
                MessageBox.Show("Введите правильно индекс.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Oblast.Text))
            {
                MessageBox.Show("Поле Область должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Gorod.Text))
            {
                MessageBox.Show("Поле Город должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Ulica.Text))
            {
                MessageBox.Show("Поле Улица должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Dom.Text))
            {
                MessageBox.Show("Поле Дом должно быть заполнено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (int.TryParse(Dom.Text, out int domValue))
            {
                if (domValue < 0 || domValue > 999)
                {
                    MessageBox.Show("Введите правильно дом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите корректный номер дома.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (int.TryParse(Reyting.Text, out int rating))
            {
                if (rating < 0 || rating > 10)
                {
                    MessageBox.Show("Рейтинг должен быть в пределах от 0 до 10.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Рейтинг должен быть числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new KabanovExamContext())
            {
                if (_isEditMode)
                {
                    var partnerToUpdate = context.Partners
                        .First(p => p.Partners_ID == _partner.Partners_ID);

                    partnerToUpdate.NaimenovaniePartnera = NaimenovaniePartnera.Text;
                    partnerToUpdate.PartnersType_ID = (int)PartnerTypeComboBox.SelectedValue;
                    partnerToUpdate.Familiya = Familiya.Text;
                    partnerToUpdate.Imya = Imya.Text;
                    partnerToUpdate.Otchestvo = Otchestvo.Text;
                    partnerToUpdate.Telephone = Telephone.Text;
                    partnerToUpdate.Email = Email.Text;
                    partnerToUpdate.Index = Index.Text;
                    partnerToUpdate.Oblast = Oblast.Text;
                    partnerToUpdate.Gorod = Gorod.Text;
                    partnerToUpdate.Ulica = Ulica.Text;
                    partnerToUpdate.Dom = domValue;
                    partnerToUpdate.Reyting = rating;
                    partnerToUpdate.INN = INN.Text;

                }
                else
                {
                    var newPartner = new Partner
                    {
                        NaimenovaniePartnera = NaimenovaniePartnera.Text,
                        PartnersType_ID = (int)PartnerTypeComboBox.SelectedValue,
                        Familiya = Familiya.Text,
                        Imya = Imya.Text,
                        Otchestvo = Otchestvo.Text,
                        Telephone = Telephone.Text,
                        Email = Email.Text,
                        Index = Index.Text,
                        Oblast = Oblast.Text,
                        Gorod = Gorod.Text,
                        Ulica = Ulica.Text,
                        Dom = domValue,
                        Reyting = rating,
                        INN = INN.Text
                    };

                    context.Partners.Add(newPartner);
                }

                context.SaveChanges();
            }

            Close();
        }

        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }
        private void LettersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Zа-яА-ЯёЁ]+$");
        }
    }
}
