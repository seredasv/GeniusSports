using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Autofac;
using Test.Core;

namespace Test
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class DetailActivity : AppCompatActivity
    {
        private static readonly string Name = "name_code";

        private Button _btn;
        private EditText _etName, _etSurname;

        public IDataStorage DataStorage { get; set; }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            if (_etName != null && _etSurname != null
                && !string.IsNullOrEmpty(_etName.Text) && !string.IsNullOrEmpty(_etSurname.Text))
            {
                DataStorage.AddPerson(_etName.Text, _etSurname.Text);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            DataStorage = MainApp.Container.Resolve<DataStorage>();

            SetContentView(Resource.Layout.activity_detail);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Test app";

            //var bundle = Intent.GetStringExtra(Name);
            //if (!string.IsNullOrEmpty(bundle))
            //{
            //    var list = bundle.Split(',');
            //}

            _etName = FindViewById<EditText>(Resource.Id.et_name);
            _etSurname = FindViewById<EditText>(Resource.Id.et_surname);
            _btn = FindViewById<Button>(Resource.Id.button);
            _btn.Click += Btn_Click;
        }

        protected override void OnStop()
        {
            base.OnStop();

            if (_btn != null)
                _btn.Click += Btn_Click;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_toolbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_back)
            {
                Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}