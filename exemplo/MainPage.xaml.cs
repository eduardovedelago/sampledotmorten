using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using dotMorten.Xamarin.Forms;
using Xamarin.Forms;

namespace exemplo
{
    
    public partial class MainPage : ContentPage
    {

        public List<string> Users { get; }
        public List<string> OtherData { get; }

        public MainPage()
        {

            InitializeComponent();
            this.BindingContext = this;



            Users = new List<string>();
            Users.Add("Bertuzzi");
            Users.Add("Bruna");
            Users.Add("Polly");
            Users.Add("Rodolfo");
            Users.Add("Lester");



            OtherData = new List<string>();
            OtherData.Add("yellow");
            OtherData.Add("blue");
            OtherData.Add("green");
            OtherData.Add("gray");
            OtherData.Add("white");
            OtherData.Add("black");
        }        
      
       

      


        //Evento de AutoComplete (1)
        private void AutoSuggestBox_TextChanged1(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            AutoSuggestBox box = (AutoSuggestBox)sender;

            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                    box.ItemsSource = null;                
            else
                {
                    var suggestions = ObterSugestoesUsers(box.Text);
                    box.ItemsSource = suggestions.ToList();
                }
            }
        }

        public IEnumerable<string> ObterSugestoesUsers(string text)
        {
            return Users.Where(x => x.StartsWith(text, StringComparison.InvariantCultureIgnoreCase));
        }







        //Evento de AutoComplete (2)
        private void AutoSuggestBox_TextChanged2(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            AutoSuggestBox box = (AutoSuggestBox)sender;

            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                    box.ItemsSource = null;
                else
                {
                    var suggestions = ObterSugestoesOtherData(box.Text);
                    box.ItemsSource = suggestions.ToList();
                }
            }
        }


        public IEnumerable<string> ObterSugestoesOtherData(string text)
        {
            return OtherData.Where(x => x.StartsWith(text, StringComparison.InvariantCultureIgnoreCase));
        }

    }
}
