using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections.ObjectModel;

namespace Hologla{
	public static class UserSettings {

		//AR/MR/VR.
		public static HologlaCameraManager.ViewMode viewMode = HologlaCameraManager.ViewMode.MR ;
		//1眼/2眼.
		public static HologlaCameraManager.EyeMode eyeMode = HologlaCameraManager.EyeMode.TwoEyes ;
		//瞳孔間距離.
		public static float interpupillaryDistance = 64.0f ;
		//起動時にゲームシーンをすぐに開くかどうか.
		public static bool isLaunchGameScene = false ;
		//表示領域サイズ設定.
		public static HologlaCameraManager.ViewSize viewSize = HologlaCameraManager.ViewSize.Size1 ;

		//設定データのバージョン情報.
		private static int dataVersion = 1 ;

		//表示領域サイズに対応したビューポートサイズリスト.
		public static readonly ReadOnlyCollection<Vector2> viewportSizeList = new ReadOnlyCollection<Vector2>(new Vector2[]
			{new Vector2(0.5f, 1.0f),
			new Vector2(0.45f, 0.9f),
			new Vector2(0.4f, 0.8f),
			new Vector2(0.35f, 0.7f),});

		private const string SETTING_KEY_DATA_VERSION = "Hologla_DataVersion" ;

		private const string SETTING_KEY_VIEW_MODE = "Hologla_ViewMode" ;
		private const string SETTING_KEY_EYE_MODE = "Hologla_EyeMode" ;
		private const string SETTING_KEY_IPD = "Hologla_InterpupillaryDistance" ;
		private const string SETTING_KEY_VIEW_SIZE = "Hologla_ViewSize" ;
		private const string SETTING_KEY_IS_LAUNCH_GAME = "Hologla_IsLaunchGameScene" ;


		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void ReadSettings( )
		{
			//有効なデータがない場合は初期値データを出力しておく.
			if( false == HasValidSettingData( ) ){
				WriteSettings( );
			}

			viewMode = (HologlaCameraManager.ViewMode)PlayerPrefs.GetInt(SETTING_KEY_VIEW_MODE, (int)viewMode);
			eyeMode = (HologlaCameraManager.EyeMode)PlayerPrefs.GetInt(SETTING_KEY_EYE_MODE, (int)eyeMode);
			interpupillaryDistance = PlayerPrefs.GetFloat(SETTING_KEY_IPD, interpupillaryDistance);
			viewSize = (HologlaCameraManager.ViewSize)PlayerPrefs.GetInt(SETTING_KEY_VIEW_SIZE, (int)viewSize);
			isLaunchGameScene = bool.Parse(PlayerPrefs.GetString(SETTING_KEY_IPD, isLaunchGameScene.ToString( )));

			return;
		}


		public static void WriteSettings( )
		{
			PlayerPrefs.SetInt(SETTING_KEY_DATA_VERSION, dataVersion);

			PlayerPrefs.SetInt(SETTING_KEY_VIEW_MODE, (int)viewMode);
			PlayerPrefs.SetInt(SETTING_KEY_EYE_MODE, (int)eyeMode);
			PlayerPrefs.SetFloat(SETTING_KEY_IPD, interpupillaryDistance);
			PlayerPrefs.SetInt(SETTING_KEY_VIEW_SIZE, (int)viewSize);
			PlayerPrefs.SetString(SETTING_KEY_IPD, isLaunchGameScene.ToString( ));

			return;
		}


		private static bool HasValidSettingData( )
		{
			if( false == PlayerPrefs.HasKey(SETTING_KEY_VIEW_MODE) ){
				return false;
			}

			return true;
		}


	}
}
