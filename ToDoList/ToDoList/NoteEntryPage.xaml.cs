using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(Object Sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename=Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");

                File.WriteAllText(filename, note.Text);
            }
            else
            {   
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();

        }

        async void OnDeleteButtonClicked(Object Sender, EventArgs e)
        {
            var note = BindingContext as Note;  // or BindingContext as Note (Note)BindingContext

            if (note == null)
                return;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);

            }
            await Navigation.PopAsync();

           


        }
    }
}