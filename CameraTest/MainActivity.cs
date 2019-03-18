using Android.App;
using Android.Content;
using Android.Widget;
using Android.Provider;
using Android.OS;
using Android.Runtime;
using Android.Graphics;

namespace CameraTest
{
    [Activity(Label = "CameraTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ImageView imgView1;
        Button cameraBtn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Definir nossa visualização do recurso de layout "Main"
            SetContentView(Resource.Layout.Main);
            cameraBtn = FindViewById<Button>(Resource.Id.bcamera);
            imgView1 = FindViewById<ImageView>(Resource.Id.imgvw1);

            cameraBtn.Click += CameraBtn_Click;
        }

        // Faz a imagem da câmera aparecer no ImageView
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            global::Android.Graphics.Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            imgView1.SetImageBitmap(bitmap);
        }

        // Abre o text view com a imagem da camera
        private void CameraBtn_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
    }   
}

