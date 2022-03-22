using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Zave.Torbat.Siman.Android.Adapters;
using Zave.Torbat.Siman.Co.Core.Models;
using Zave.Torbat.Siman.Co.Presentation.Concretes;
using Zave.Torbat.Siman.Co.Presentation.Interfaces;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace Zave.Torbat.Siman.Android
{
    [Activity(Theme = "@style/AppTheme",Label = "TakeLoadActivity")]
    public class TakeLoadActivity : AppCompatActivity,ITakeLoadView
    {
        private Spinner _townDropDown;
        private ListViewCompat _loadListView;
        private List<string> _towns;
        private List<Load> _loads;
        private Button _cancelLoadButton;
        public ITakeLoadPresenter Presenter { get; set; }
        public object ViewContext { get; set; }
        private bool _townByAppSelected = false;

        private TextView _nameText;
        private TextView _cardText;

        public string FullName
        {
            set => _nameText.Text = $"{value} گرامی خوش آمدید";
        }

        public string CardNumber
        {
            set => _cardText.Text = $"شماره کارت بارگیری {value}";
        }
        public List<Load> Loads
        {
            get => _loads;
            set
            {
                _loads = value;
                _loadListView.Adapter=new TakeLoadListAdapter(this,Loads);
                //var ee = _loadListView.Adapter.IsEnabled(0);
            }
        }

        public void CancelTurnSuccessful()
        {
            Toast.MakeText(this, "انصراف از بارگیری با موفقیت انجام شد", ToastLength.Long).Show();
        }

        public void TakeLoadTimeout()
        {
            Toast.MakeText(this, "مدت زمان مجاز انتخاب بار به اتمام رسیده است", ToastLength.Long).Show();
            Presenter.CancelTurn();
        }

        public List<string> Towns
        {
            get => _towns;
            set
            {
                _towns = value;
                //((ArrayAdapter) _townDropDown.Adapter)?.NotifyDataSetChanged();
                _townDropDown.ItemSelected -= _townDropDown_ItemSelected;
                _townByAppSelected = true;
                _townDropDown.Adapter = new ArrayAdapter(this, global::Android.Resource.Layout.SimpleSpinnerDropDownItem, Towns);
                _townDropDown.ItemSelected += _townDropDown_ItemSelected;
            }
        }

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakeLoadView);
            // Create your application here
            BindControls();
            SetPresenter();
            Presenter.SetApplicationHeader();
            Presenter.GetTownsList();
        }

        

        private void BindControls()
        {
            var logoutButton = FindViewById<Button>(Resource.Id.buttonLogoutLoad);
            logoutButton.Click += LogoutButton_Click;

            _townDropDown = FindViewById<Spinner>(Resource.Id.dropDownTown);
            //_townDropDown.ItemSelected += _townDropDown_ItemSelected;
            _nameText = FindViewById<TextView>(Resource.Id.nameTakeLoad);
            _cardText = FindViewById<TextView>(Resource.Id.cardTakeLoad);

            _loadListView = FindViewById<ListViewCompat>(Resource.Id.listViewLoads);
            _loadListView.ChoiceMode = ChoiceMode.Single;
            _loadListView.ItemClick -= _loadListView_ItemClick;
            _loadListView.ItemClick += _loadListView_ItemClick;

            _cancelLoadButton = FindViewById<Button>(Resource.Id.btnCancelTurn);
            _cancelLoadButton.Click -= _cancelLoadButton_Click;
            _cancelLoadButton.Click += _cancelLoadButton_Click;

        }

        private void _cancelLoadButton_Click(object sender, EventArgs e)
        {
            Presenter.CancelTurn();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Presenter.Logout(this);
        }

        private void _loadListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var itemPosition = e.Position;
            var selectedItem = Loads[itemPosition];


            AlertDialog.Builder loadDialog = new AlertDialog.Builder(this);
            TextView dialogMessageView = new TextView(this);
            dialogMessageView.Gravity = GravityFlags.Center;
            dialogMessageView.Text = "بار" + selectedItem.Product + " به حجم" + selectedItem.Amount + " برای مشتری:" +
                                     selectedItem.CustomerName + " توسط شما انتخاب شده است" + "\n آیا مورد تایید است؟";

            TextView dialogTitleView = new TextView(this);
            dialogTitleView.Gravity = GravityFlags.Center;
            dialogTitleView.Text = "تایید سفارش بارگیری";

            loadDialog.SetView(dialogMessageView);
            loadDialog.SetCustomTitle(dialogTitleView);
            loadDialog.SetNegativeButton("لغو", (o, args) => ((AlertDialog)o).Cancel());
            loadDialog.SetPositiveButton("تایید", (o, args) =>
            {
                Presenter.LoadSelected(selectedItem);
                ((AlertDialog) o).Cancel();
            });
            loadDialog.Show();
            
        }

        private void _townDropDown_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (_townByAppSelected)
            {
                _townByAppSelected = false;
                return;
            }
            var selectedTownPosition = e.Position;
            var selectedTowName = Towns[selectedTownPosition];
            Presenter.GetLoadsData(selectedTowName);
        }

        private void SetPresenter()
        {
            this.Presenter = new TakeLoadPresenter(MainActivity.ApplicationController);
            Presenter.View = this;
            ViewContext = this;
            
        }

    }
}