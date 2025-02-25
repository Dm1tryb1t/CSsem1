﻿using ResourcesAndDataBinding.Models;
using ResourcesAndDataBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResourcesAndDataBinding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {

        private ContactViewModel ViewModel { get; set; }
        public CollectionViewPage()
        {
            InitializeComponent();
            ViewModel = new ContactViewModel();
            BindingContext = ViewModel;
        }

        private void ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // In case of single selection
            var selectedPerson = this.ContactList.SelectedItem as Contact;

            // In case of multi-selection:
            var singlePerson = e.CurrentSelection.FirstOrDefault() as Contact;

            var selectedObjects = e.CurrentSelection.Cast<Contact>();
            foreach (var person in selectedObjects)
            {
                // Handle your object properties here...
            }
        }
    }
}