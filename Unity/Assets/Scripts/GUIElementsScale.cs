using UnityEngine;
using System.Collections;

public class GUIELementScale : MonoBehaviour 
{
	public class ScreenScale{
		private float _native_width;
		private float _native_height;
		private float screen_width;
		private float screen_height;
		private float ratio_x;
		private float ratio_y;
		//At this script initialization
		public ScreenScale (float native_width, float native_height){
			_native_width = native_width;
			_native_height = native_height; 
		}

		public Matrix4x4 AdjustOnGUI(){
			GetScreenResolutions();
			return Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratio_x, ratio_y, 1));
		}

		public Rect AdjustRect(float left, float top, float width, float height){
			return new Rect(left, top, width*ratio_x, height*ratio_y);
		}
		public float AdjustX(float x){
			return  x*ratio_x;
		}
		public float AdjustY(float y){
			return y*ratio_y;
		}

		private void GetScreenResolutions(){
			screen_width = Screen.width;
			screen_height = Screen.height;
			ratio_x = screen_width/_native_width;
			ratio_y = screen_height/_native_height;
		}
	}
}
