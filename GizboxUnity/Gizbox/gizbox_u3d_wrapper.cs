public class gizbox_u3d_wrapper
{

	public static void GizboxUnityExampleInterop_Console__Log_Static(System.String arg0)
	{
		GizboxUnityExampleInterop.Console__Log(arg0);
	}
	public static UnityEngine.Object GizboxUnityExampleInterop_FindObjectOfType_Static(System.String arg0)
	{
		return GizboxUnityExampleInterop.FindObjectOfType(arg0);
	}

	public static System.String UnityEngine__Object_get_name(UnityEngine.Object obj)
	{
		return obj.name;
	}
	public static void UnityEngine__Object_set_name(UnityEngine.Object obj, System.String newv)
	{
		obj.name = newv;
	}
	public static int UnityEngine__Object_get_hideFlags(UnityEngine.Object obj)
	{
		return (int)obj.hideFlags;
	}
	public static void UnityEngine__Object_set_hideFlags(UnityEngine.Object obj, int newv)
	{
		obj.hideFlags = (UnityEngine.HideFlags)newv;
	}
	public static System.Int32 UnityEngine__Object_GetInstanceID(UnityEngine.Object arg0)
	{
		return arg0.GetInstanceID();
	}
	public static System.Int32 UnityEngine__Object_GetHashCode(UnityEngine.Object arg0)
	{
		return arg0.GetHashCode();
	}
	public static System.String UnityEngine__Object_ToString(UnityEngine.Object arg0)
	{
		return arg0.ToString();
	}
	public static UnityEngine.Object UnityEngine__Object_Instantiate_Static(UnityEngine.Object arg0, UnityEngine.Vector3 arg1, UnityEngine.Quaternion arg2)
	{
		return UnityEngine.Object.Instantiate(arg0, arg1, arg2);
	}
	public static UnityEngine.Object UnityEngine__Object_Instantiate_Static(UnityEngine.Object arg0, UnityEngine.Vector3 arg1, UnityEngine.Quaternion arg2, UnityEngine.Transform arg3)
	{
		return UnityEngine.Object.Instantiate(arg0, arg1, arg2, arg3);
	}
	public static UnityEngine.Object UnityEngine__Object_Instantiate_Static(UnityEngine.Object arg0)
	{
		return UnityEngine.Object.Instantiate(arg0);
	}
	public static UnityEngine.Object UnityEngine__Object_Instantiate_Static(UnityEngine.Object arg0, UnityEngine.Transform arg1)
	{
		return UnityEngine.Object.Instantiate(arg0, arg1);
	}
	public static UnityEngine.Object UnityEngine__Object_Instantiate_Static(UnityEngine.Object arg0, UnityEngine.Transform arg1, System.Boolean arg2)
	{
		return UnityEngine.Object.Instantiate(arg0, arg1, arg2);
	}
	public static void UnityEngine__Object_Destroy_Static(UnityEngine.Object arg0, System.Single arg1)
	{
		UnityEngine.Object.Destroy(arg0, arg1);
	}
	public static void UnityEngine__Object_Destroy_Static(UnityEngine.Object arg0)
	{
		UnityEngine.Object.Destroy(arg0);
	}
	public static void UnityEngine__Object_DestroyImmediate_Static(UnityEngine.Object arg0, System.Boolean arg1)
	{
		UnityEngine.Object.DestroyImmediate(arg0, arg1);
	}
	public static void UnityEngine__Object_DestroyImmediate_Static(UnityEngine.Object arg0)
	{
		UnityEngine.Object.DestroyImmediate(arg0);
	}
	public static void UnityEngine__Object_DontDestroyOnLoad_Static(UnityEngine.Object arg0)
	{
		UnityEngine.Object.DontDestroyOnLoad(arg0);
	}
	public static System.Single UnityEngine__Input_GetAxis_Static(System.String arg0)
	{
		return UnityEngine.Input.GetAxis(arg0);
	}
	public static System.Single UnityEngine__Input_GetAxisRaw_Static(System.String arg0)
	{
		return UnityEngine.Input.GetAxisRaw(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetButton_Static(System.String arg0)
	{
		return UnityEngine.Input.GetButton(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetButtonDown_Static(System.String arg0)
	{
		return UnityEngine.Input.GetButtonDown(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetButtonUp_Static(System.String arg0)
	{
		return UnityEngine.Input.GetButtonUp(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetMouseButton_Static(System.Int32 arg0)
	{
		return UnityEngine.Input.GetMouseButton(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetMouseButtonDown_Static(System.Int32 arg0)
	{
		return UnityEngine.Input.GetMouseButtonDown(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetMouseButtonUp_Static(System.Int32 arg0)
	{
		return UnityEngine.Input.GetMouseButtonUp(arg0);
	}
	public static void UnityEngine__Input_ResetInputAxes_Static()
	{
		UnityEngine.Input.ResetInputAxes();
	}
	public static System.Boolean UnityEngine__Input_IsJoystickPreconfigured_Static(System.String arg0)
	{
		return UnityEngine.Input.IsJoystickPreconfigured(arg0);
	}
	public static UnityEngine.Touch UnityEngine__Input_GetTouch_Static(System.Int32 arg0)
	{
		return UnityEngine.Input.GetTouch(arg0);
	}
	public static UnityEngine.AccelerationEvent UnityEngine__Input_GetAccelerationEvent_Static(System.Int32 arg0)
	{
		return UnityEngine.Input.GetAccelerationEvent(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetKey_Static(int arg0)
	{
		return UnityEngine.Input.GetKey((UnityEngine.KeyCode)arg0);
	}
	public static System.Boolean UnityEngine__Input_GetKey_Static(System.String arg0)
	{
		return UnityEngine.Input.GetKey(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetKeyUp_Static(int arg0)
	{
		return UnityEngine.Input.GetKeyUp((UnityEngine.KeyCode)arg0);
	}
	public static System.Boolean UnityEngine__Input_GetKeyUp_Static(System.String arg0)
	{
		return UnityEngine.Input.GetKeyUp(arg0);
	}
	public static System.Boolean UnityEngine__Input_GetKeyDown_Static(int arg0)
	{
		return UnityEngine.Input.GetKeyDown((UnityEngine.KeyCode)arg0);
	}
	public static System.Boolean UnityEngine__Input_GetKeyDown_Static(System.String arg0)
	{
		return UnityEngine.Input.GetKeyDown(arg0);
	}
	public static System.Boolean UnityEngine__LocationService_get_isEnabledByUser(UnityEngine.LocationService obj)
	{
		return obj.isEnabledByUser;
	}
	public static int UnityEngine__LocationService_get_status(UnityEngine.LocationService obj)
	{
		return (int)obj.status;
	}
	public static UnityEngine.LocationInfo UnityEngine__LocationService_get_lastData(UnityEngine.LocationService obj)
	{
		return obj.lastData;
	}
	public static void UnityEngine__LocationService_Start(UnityEngine.LocationService arg0, System.Single arg1, System.Single arg2)
	{
		arg0.Start(arg1, arg2);
	}
	public static void UnityEngine__LocationService_Start(UnityEngine.LocationService arg0, System.Single arg1)
	{
		arg0.Start(arg1);
	}
	public static void UnityEngine__LocationService_Start(UnityEngine.LocationService arg0)
	{
		arg0.Start();
	}
	public static void UnityEngine__LocationService_Stop(UnityEngine.LocationService arg0)
	{
		arg0.Stop();
	}
	public static System.Single UnityEngine__Compass_get_magneticHeading(UnityEngine.Compass obj)
	{
		return obj.magneticHeading;
	}
	public static System.Single UnityEngine__Compass_get_trueHeading(UnityEngine.Compass obj)
	{
		return obj.trueHeading;
	}
	public static System.Single UnityEngine__Compass_get_headingAccuracy(UnityEngine.Compass obj)
	{
		return obj.headingAccuracy;
	}
	public static UnityEngine.Vector3 UnityEngine__Compass_get_rawVector(UnityEngine.Compass obj)
	{
		return obj.rawVector;
	}
	public static System.Boolean UnityEngine__Compass_get_enabled(UnityEngine.Compass obj)
	{
		return obj.enabled;
	}
	public static void UnityEngine__Compass_set_enabled(UnityEngine.Compass obj, System.Boolean newv)
	{
		obj.enabled = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Gyroscope_get_rotationRate(UnityEngine.Gyroscope obj)
	{
		return obj.rotationRate;
	}
	public static UnityEngine.Vector3 UnityEngine__Gyroscope_get_rotationRateUnbiased(UnityEngine.Gyroscope obj)
	{
		return obj.rotationRateUnbiased;
	}
	public static UnityEngine.Vector3 UnityEngine__Gyroscope_get_gravity(UnityEngine.Gyroscope obj)
	{
		return obj.gravity;
	}
	public static UnityEngine.Vector3 UnityEngine__Gyroscope_get_userAcceleration(UnityEngine.Gyroscope obj)
	{
		return obj.userAcceleration;
	}
	public static UnityEngine.Quaternion UnityEngine__Gyroscope_get_attitude(UnityEngine.Gyroscope obj)
	{
		return obj.attitude;
	}
	public static System.Boolean UnityEngine__Gyroscope_get_enabled(UnityEngine.Gyroscope obj)
	{
		return obj.enabled;
	}
	public static void UnityEngine__Gyroscope_set_enabled(UnityEngine.Gyroscope obj, System.Boolean newv)
	{
		obj.enabled = newv;
	}
	public static System.Single UnityEngine__Gyroscope_get_updateInterval(UnityEngine.Gyroscope obj)
	{
		return obj.updateInterval;
	}
	public static void UnityEngine__Gyroscope_set_updateInterval(UnityEngine.Gyroscope obj, System.Single newv)
	{
		obj.updateInterval = newv;
	}
	public static void UnityEngine__Vector3_Set(UnityEngine.Vector3 arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		arg0.Set(arg1, arg2, arg3);
	}
	public static void UnityEngine__Vector3_Scale(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		arg0.Scale(arg1);
	}
	public static System.Int32 UnityEngine__Vector3_GetHashCode(UnityEngine.Vector3 arg0)
	{
		return arg0.GetHashCode();
	}
	public static System.Boolean UnityEngine__Vector3_Equals(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.Equals(arg1);
	}
	public static void UnityEngine__Vector3_Normalize(UnityEngine.Vector3 arg0)
	{
		arg0.Normalize();
	}
	public static System.String UnityEngine__Vector3_ToString(UnityEngine.Vector3 arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Vector3_ToString(UnityEngine.Vector3 arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Slerp_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, System.Single arg2)
	{
		return UnityEngine.Vector3.Slerp(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_SlerpUnclamped_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, System.Single arg2)
	{
		return UnityEngine.Vector3.SlerpUnclamped(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_RotateTowards_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, System.Single arg2, System.Single arg3)
	{
		return UnityEngine.Vector3.RotateTowards(arg0, arg1, arg2, arg3);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Lerp_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, System.Single arg2)
	{
		return UnityEngine.Vector3.Lerp(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_LerpUnclamped_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, System.Single arg2)
	{
		return UnityEngine.Vector3.LerpUnclamped(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_MoveTowards_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, System.Single arg2)
	{
		return UnityEngine.Vector3.MoveTowards(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Scale_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Scale(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Cross_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Cross(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Reflect_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Reflect(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Normalize_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Vector3.Normalize(arg0);
	}
	public static System.Single UnityEngine__Vector3_Dot_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Dot(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Project_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Project(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_ProjectOnPlane_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.ProjectOnPlane(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector3_Angle_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Angle(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector3_SignedAngle_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		return UnityEngine.Vector3.SignedAngle(arg0, arg1, arg2);
	}
	public static System.Single UnityEngine__Vector3_Distance_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Distance(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_ClampMagnitude_Static(UnityEngine.Vector3 arg0, System.Single arg1)
	{
		return UnityEngine.Vector3.ClampMagnitude(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector3_Magnitude_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Vector3.Magnitude(arg0);
	}
	public static System.Single UnityEngine__Vector3_SqrMagnitude_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Vector3.SqrMagnitude(arg0);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Min_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Min(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Vector3_Max_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Vector3.Max(arg0, arg1);
	}
	public static void UnityEngine__Quaternion_Set(UnityEngine.Quaternion arg0, System.Single arg1, System.Single arg2, System.Single arg3, System.Single arg4)
	{
		arg0.Set(arg1, arg2, arg3, arg4);
	}
	public static void UnityEngine__Quaternion_SetLookRotation(UnityEngine.Quaternion arg0, UnityEngine.Vector3 arg1)
	{
		arg0.SetLookRotation(arg1);
	}
	public static void UnityEngine__Quaternion_SetLookRotation(UnityEngine.Quaternion arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		arg0.SetLookRotation(arg1, arg2);
	}
	public static void UnityEngine__Quaternion_SetFromToRotation(UnityEngine.Quaternion arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		arg0.SetFromToRotation(arg1, arg2);
	}
	public static void UnityEngine__Quaternion_Normalize(UnityEngine.Quaternion arg0)
	{
		arg0.Normalize();
	}
	public static System.Int32 UnityEngine__Quaternion_GetHashCode(UnityEngine.Quaternion arg0)
	{
		return arg0.GetHashCode();
	}
	public static System.Boolean UnityEngine__Quaternion_Equals(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1)
	{
		return arg0.Equals(arg1);
	}
	public static System.String UnityEngine__Quaternion_ToString(UnityEngine.Quaternion arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Quaternion_ToString(UnityEngine.Quaternion arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_FromToRotation_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Quaternion.FromToRotation(arg0, arg1);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_Inverse_Static(UnityEngine.Quaternion arg0)
	{
		return UnityEngine.Quaternion.Inverse(arg0);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_Slerp_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1, System.Single arg2)
	{
		return UnityEngine.Quaternion.Slerp(arg0, arg1, arg2);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_SlerpUnclamped_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1, System.Single arg2)
	{
		return UnityEngine.Quaternion.SlerpUnclamped(arg0, arg1, arg2);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_Lerp_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1, System.Single arg2)
	{
		return UnityEngine.Quaternion.Lerp(arg0, arg1, arg2);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_LerpUnclamped_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1, System.Single arg2)
	{
		return UnityEngine.Quaternion.LerpUnclamped(arg0, arg1, arg2);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_AngleAxis_Static(System.Single arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Quaternion.AngleAxis(arg0, arg1);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_LookRotation_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Quaternion.LookRotation(arg0, arg1);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_LookRotation_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Quaternion.LookRotation(arg0);
	}
	public static System.Single UnityEngine__Quaternion_Dot_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1)
	{
		return UnityEngine.Quaternion.Dot(arg0, arg1);
	}
	public static System.Single UnityEngine__Quaternion_Angle_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1)
	{
		return UnityEngine.Quaternion.Angle(arg0, arg1);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_Euler_Static(System.Single arg0, System.Single arg1, System.Single arg2)
	{
		return UnityEngine.Quaternion.Euler(arg0, arg1, arg2);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_Euler_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Quaternion.Euler(arg0);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_RotateTowards_Static(UnityEngine.Quaternion arg0, UnityEngine.Quaternion arg1, System.Single arg2)
	{
		return UnityEngine.Quaternion.RotateTowards(arg0, arg1, arg2);
	}
	public static UnityEngine.Quaternion UnityEngine__Quaternion_Normalize_Static(UnityEngine.Quaternion arg0)
	{
		return UnityEngine.Quaternion.Normalize(arg0);
	}
	public static System.Boolean UnityEngine__Matrix4x4_ValidTRS(UnityEngine.Matrix4x4 arg0)
	{
		return arg0.ValidTRS();
	}
	public static void UnityEngine__Matrix4x4_SetTRS(UnityEngine.Matrix4x4 arg0, UnityEngine.Vector3 arg1, UnityEngine.Quaternion arg2, UnityEngine.Vector3 arg3)
	{
		arg0.SetTRS(arg1, arg2, arg3);
	}
	public static System.Int32 UnityEngine__Matrix4x4_GetHashCode(UnityEngine.Matrix4x4 arg0)
	{
		return arg0.GetHashCode();
	}
	public static System.Boolean UnityEngine__Matrix4x4_Equals(UnityEngine.Matrix4x4 arg0, UnityEngine.Matrix4x4 arg1)
	{
		return arg0.Equals(arg1);
	}
	public static UnityEngine.Vector4 UnityEngine__Matrix4x4_GetColumn(UnityEngine.Matrix4x4 arg0, System.Int32 arg1)
	{
		return arg0.GetColumn(arg1);
	}
	public static UnityEngine.Vector4 UnityEngine__Matrix4x4_GetRow(UnityEngine.Matrix4x4 arg0, System.Int32 arg1)
	{
		return arg0.GetRow(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Matrix4x4_GetPosition(UnityEngine.Matrix4x4 arg0)
	{
		return arg0.GetPosition();
	}
	public static void UnityEngine__Matrix4x4_SetColumn(UnityEngine.Matrix4x4 arg0, System.Int32 arg1, UnityEngine.Vector4 arg2)
	{
		arg0.SetColumn(arg1, arg2);
	}
	public static void UnityEngine__Matrix4x4_SetRow(UnityEngine.Matrix4x4 arg0, System.Int32 arg1, UnityEngine.Vector4 arg2)
	{
		arg0.SetRow(arg1, arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Matrix4x4_MultiplyPoint(UnityEngine.Matrix4x4 arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.MultiplyPoint(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Matrix4x4_MultiplyPoint3x4(UnityEngine.Matrix4x4 arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.MultiplyPoint3x4(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Matrix4x4_MultiplyVector(UnityEngine.Matrix4x4 arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.MultiplyVector(arg1);
	}
	public static UnityEngine.Plane UnityEngine__Matrix4x4_TransformPlane(UnityEngine.Matrix4x4 arg0, UnityEngine.Plane arg1)
	{
		return arg0.TransformPlane(arg1);
	}
	public static System.String UnityEngine__Matrix4x4_ToString(UnityEngine.Matrix4x4 arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Matrix4x4_ToString(UnityEngine.Matrix4x4 arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static System.Single UnityEngine__Matrix4x4_Determinant_Static(UnityEngine.Matrix4x4 arg0)
	{
		return UnityEngine.Matrix4x4.Determinant(arg0);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_TRS_Static(UnityEngine.Vector3 arg0, UnityEngine.Quaternion arg1, UnityEngine.Vector3 arg2)
	{
		return UnityEngine.Matrix4x4.TRS(arg0, arg1, arg2);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Inverse_Static(UnityEngine.Matrix4x4 arg0)
	{
		return UnityEngine.Matrix4x4.Inverse(arg0);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Transpose_Static(UnityEngine.Matrix4x4 arg0)
	{
		return UnityEngine.Matrix4x4.Transpose(arg0);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Ortho_Static(System.Single arg0, System.Single arg1, System.Single arg2, System.Single arg3, System.Single arg4, System.Single arg5)
	{
		return UnityEngine.Matrix4x4.Ortho(arg0, arg1, arg2, arg3, arg4, arg5);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Perspective_Static(System.Single arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return UnityEngine.Matrix4x4.Perspective(arg0, arg1, arg2, arg3);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_LookAt_Static(UnityEngine.Vector3 arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		return UnityEngine.Matrix4x4.LookAt(arg0, arg1, arg2);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Frustum_Static(System.Single arg0, System.Single arg1, System.Single arg2, System.Single arg3, System.Single arg4, System.Single arg5)
	{
		return UnityEngine.Matrix4x4.Frustum(arg0, arg1, arg2, arg3, arg4, arg5);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Frustum_Static(UnityEngine.FrustumPlanes arg0)
	{
		return UnityEngine.Matrix4x4.Frustum(arg0);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Scale_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Matrix4x4.Scale(arg0);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Translate_Static(UnityEngine.Vector3 arg0)
	{
		return UnityEngine.Matrix4x4.Translate(arg0);
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Matrix4x4_Rotate_Static(UnityEngine.Quaternion arg0)
	{
		return UnityEngine.Matrix4x4.Rotate(arg0);
	}
	public static void UnityEngine__Vector4_Set(UnityEngine.Vector4 arg0, System.Single arg1, System.Single arg2, System.Single arg3, System.Single arg4)
	{
		arg0.Set(arg1, arg2, arg3, arg4);
	}
	public static void UnityEngine__Vector4_Scale(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		arg0.Scale(arg1);
	}
	public static System.Int32 UnityEngine__Vector4_GetHashCode(UnityEngine.Vector4 arg0)
	{
		return arg0.GetHashCode();
	}
	public static System.Boolean UnityEngine__Vector4_Equals(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return arg0.Equals(arg1);
	}
	public static void UnityEngine__Vector4_Normalize(UnityEngine.Vector4 arg0)
	{
		arg0.Normalize();
	}
	public static System.String UnityEngine__Vector4_ToString(UnityEngine.Vector4 arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Vector4_ToString(UnityEngine.Vector4 arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static System.Single UnityEngine__Vector4_SqrMagnitude(UnityEngine.Vector4 arg0)
	{
		return arg0.SqrMagnitude();
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_Lerp_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1, System.Single arg2)
	{
		return UnityEngine.Vector4.Lerp(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_LerpUnclamped_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1, System.Single arg2)
	{
		return UnityEngine.Vector4.LerpUnclamped(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_MoveTowards_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1, System.Single arg2)
	{
		return UnityEngine.Vector4.MoveTowards(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_Scale_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return UnityEngine.Vector4.Scale(arg0, arg1);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_Normalize_Static(UnityEngine.Vector4 arg0)
	{
		return UnityEngine.Vector4.Normalize(arg0);
	}
	public static System.Single UnityEngine__Vector4_Dot_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return UnityEngine.Vector4.Dot(arg0, arg1);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_Project_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return UnityEngine.Vector4.Project(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector4_Distance_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return UnityEngine.Vector4.Distance(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector4_Magnitude_Static(UnityEngine.Vector4 arg0)
	{
		return UnityEngine.Vector4.Magnitude(arg0);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_Min_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return UnityEngine.Vector4.Min(arg0, arg1);
	}
	public static UnityEngine.Vector4 UnityEngine__Vector4_Max_Static(UnityEngine.Vector4 arg0, UnityEngine.Vector4 arg1)
	{
		return UnityEngine.Vector4.Max(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector4_SqrMagnitude_Static(UnityEngine.Vector4 arg0)
	{
		return UnityEngine.Vector4.SqrMagnitude(arg0);
	}
	public static void UnityEngine__Vector2_Set(UnityEngine.Vector2 arg0, System.Single arg1, System.Single arg2)
	{
		arg0.Set(arg1, arg2);
	}
	public static void UnityEngine__Vector2_Scale(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		arg0.Scale(arg1);
	}
	public static void UnityEngine__Vector2_Normalize(UnityEngine.Vector2 arg0)
	{
		arg0.Normalize();
	}
	public static System.String UnityEngine__Vector2_ToString(UnityEngine.Vector2 arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Vector2_ToString(UnityEngine.Vector2 arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static System.Int32 UnityEngine__Vector2_GetHashCode(UnityEngine.Vector2 arg0)
	{
		return arg0.GetHashCode();
	}
	public static System.Boolean UnityEngine__Vector2_Equals(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return arg0.Equals(arg1);
	}
	public static System.Single UnityEngine__Vector2_SqrMagnitude(UnityEngine.Vector2 arg0)
	{
		return arg0.SqrMagnitude();
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_Lerp_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1, System.Single arg2)
	{
		return UnityEngine.Vector2.Lerp(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_LerpUnclamped_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1, System.Single arg2)
	{
		return UnityEngine.Vector2.LerpUnclamped(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_MoveTowards_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1, System.Single arg2)
	{
		return UnityEngine.Vector2.MoveTowards(arg0, arg1, arg2);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_Scale_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Scale(arg0, arg1);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_Reflect_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Reflect(arg0, arg1);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_Perpendicular_Static(UnityEngine.Vector2 arg0)
	{
		return UnityEngine.Vector2.Perpendicular(arg0);
	}
	public static System.Single UnityEngine__Vector2_Dot_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Dot(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector2_Angle_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Angle(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector2_SignedAngle_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.SignedAngle(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector2_Distance_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Distance(arg0, arg1);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_ClampMagnitude_Static(UnityEngine.Vector2 arg0, System.Single arg1)
	{
		return UnityEngine.Vector2.ClampMagnitude(arg0, arg1);
	}
	public static System.Single UnityEngine__Vector2_SqrMagnitude_Static(UnityEngine.Vector2 arg0)
	{
		return UnityEngine.Vector2.SqrMagnitude(arg0);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_Min_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Min(arg0, arg1);
	}
	public static UnityEngine.Vector2 UnityEngine__Vector2_Max_Static(UnityEngine.Vector2 arg0, UnityEngine.Vector2 arg1)
	{
		return UnityEngine.Vector2.Max(arg0, arg1);
	}
	public static void UnityEngine__Plane_SetNormalAndPosition(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		arg0.SetNormalAndPosition(arg1, arg2);
	}
	public static void UnityEngine__Plane_Set3Points(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2, UnityEngine.Vector3 arg3)
	{
		arg0.Set3Points(arg1, arg2, arg3);
	}
	public static void UnityEngine__Plane_Flip(UnityEngine.Plane arg0)
	{
		arg0.Flip();
	}
	public static void UnityEngine__Plane_Translate(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1)
	{
		arg0.Translate(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Plane_ClosestPointOnPlane(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.ClosestPointOnPlane(arg1);
	}
	public static System.Single UnityEngine__Plane_GetDistanceToPoint(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.GetDistanceToPoint(arg1);
	}
	public static System.Boolean UnityEngine__Plane_GetSide(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.GetSide(arg1);
	}
	public static System.Boolean UnityEngine__Plane_SameSide(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		return arg0.SameSide(arg1, arg2);
	}
	public static System.String UnityEngine__Plane_ToString(UnityEngine.Plane arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Plane_ToString(UnityEngine.Plane arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static UnityEngine.Plane UnityEngine__Plane_Translate_Static(UnityEngine.Plane arg0, UnityEngine.Vector3 arg1)
	{
		return UnityEngine.Plane.Translate(arg0, arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Ray_GetPoint(UnityEngine.Ray arg0, System.Single arg1)
	{
		return arg0.GetPoint(arg1);
	}
	public static System.String UnityEngine__Ray_ToString(UnityEngine.Ray arg0)
	{
		return arg0.ToString();
	}
	public static System.String UnityEngine__Ray_ToString(UnityEngine.Ray arg0, System.String arg1)
	{
		return arg0.ToString(arg1);
	}
	public static UnityEngine.Transform UnityEngine__GameObject_get_transform(UnityEngine.GameObject obj)
	{
		return obj.transform;
	}
	public static System.Int32 UnityEngine__GameObject_get_layer(UnityEngine.GameObject obj)
	{
		return obj.layer;
	}
	public static void UnityEngine__GameObject_set_layer(UnityEngine.GameObject obj, System.Int32 newv)
	{
		obj.layer = newv;
	}
	public static System.Boolean UnityEngine__GameObject_get_activeSelf(UnityEngine.GameObject obj)
	{
		return obj.activeSelf;
	}
	public static System.Boolean UnityEngine__GameObject_get_activeInHierarchy(UnityEngine.GameObject obj)
	{
		return obj.activeInHierarchy;
	}
	public static System.Boolean UnityEngine__GameObject_get_isStatic(UnityEngine.GameObject obj)
	{
		return obj.isStatic;
	}
	public static void UnityEngine__GameObject_set_isStatic(UnityEngine.GameObject obj, System.Boolean newv)
	{
		obj.isStatic = newv;
	}
	public static System.String UnityEngine__GameObject_get_tag(UnityEngine.GameObject obj)
	{
		return obj.tag;
	}
	public static void UnityEngine__GameObject_set_tag(UnityEngine.GameObject obj, System.String newv)
	{
		obj.tag = newv;
	}
	public static UnityEngine.GameObject UnityEngine__GameObject_get_gameObject(UnityEngine.GameObject obj)
	{
		return obj.gameObject;
	}
	public static UnityEngine.Component UnityEngine__GameObject_GetComponent(UnityEngine.GameObject arg0, System.String arg1)
	{
		return arg0.GetComponent(arg1);
	}
	public static void UnityEngine__GameObject_SendMessageUpwards(UnityEngine.GameObject arg0, System.String arg1, int arg2)
	{
		arg0.SendMessageUpwards(arg1, (UnityEngine.SendMessageOptions)arg2);
	}
	public static void UnityEngine__GameObject_SendMessage(UnityEngine.GameObject arg0, System.String arg1, int arg2)
	{
		arg0.SendMessage(arg1, (UnityEngine.SendMessageOptions)arg2);
	}
	public static void UnityEngine__GameObject_BroadcastMessage(UnityEngine.GameObject arg0, System.String arg1, int arg2)
	{
		arg0.BroadcastMessage(arg1, (UnityEngine.SendMessageOptions)arg2);
	}
	public static void UnityEngine__GameObject_SetActive(UnityEngine.GameObject arg0, System.Boolean arg1)
	{
		arg0.SetActive(arg1);
	}
	public static System.Boolean UnityEngine__GameObject_CompareTag(UnityEngine.GameObject arg0, System.String arg1)
	{
		return arg0.CompareTag(arg1);
	}
	public static void UnityEngine__GameObject_SendMessageUpwards(UnityEngine.GameObject arg0, System.String arg1)
	{
		arg0.SendMessageUpwards(arg1);
	}
	public static void UnityEngine__GameObject_SendMessage(UnityEngine.GameObject arg0, System.String arg1)
	{
		arg0.SendMessage(arg1);
	}
	public static void UnityEngine__GameObject_BroadcastMessage(UnityEngine.GameObject arg0, System.String arg1)
	{
		arg0.BroadcastMessage(arg1);
	}
	public static UnityEngine.GameObject UnityEngine__GameObject_CreatePrimitive_Static(int arg0)
	{
		return UnityEngine.GameObject.CreatePrimitive((UnityEngine.PrimitiveType)arg0);
	}
	public static UnityEngine.GameObject UnityEngine__GameObject_FindWithTag_Static(System.String arg0)
	{
		return UnityEngine.GameObject.FindWithTag(arg0);
	}
	public static UnityEngine.GameObject UnityEngine__GameObject_FindGameObjectWithTag_Static(System.String arg0)
	{
		return UnityEngine.GameObject.FindGameObjectWithTag(arg0);
	}
	public static UnityEngine.GameObject UnityEngine__GameObject_Find_Static(System.String arg0)
	{
		return UnityEngine.GameObject.Find(arg0);
	}
	public static UnityEngine.Transform UnityEngine__Component_get_transform(UnityEngine.Component obj)
	{
		return obj.transform;
	}
	public static UnityEngine.GameObject UnityEngine__Component_get_gameObject(UnityEngine.Component obj)
	{
		return obj.gameObject;
	}
	public static System.String UnityEngine__Component_get_tag(UnityEngine.Component obj)
	{
		return obj.tag;
	}
	public static void UnityEngine__Component_set_tag(UnityEngine.Component obj, System.String newv)
	{
		obj.tag = newv;
	}
	public static UnityEngine.Component UnityEngine__Component_GetComponent(UnityEngine.Component arg0, System.String arg1)
	{
		return arg0.GetComponent(arg1);
	}
	public static System.Boolean UnityEngine__Component_CompareTag(UnityEngine.Component arg0, System.String arg1)
	{
		return arg0.CompareTag(arg1);
	}
	public static void UnityEngine__Component_SendMessageUpwards(UnityEngine.Component arg0, System.String arg1)
	{
		arg0.SendMessageUpwards(arg1);
	}
	public static void UnityEngine__Component_SendMessageUpwards(UnityEngine.Component arg0, System.String arg1, int arg2)
	{
		arg0.SendMessageUpwards(arg1, (UnityEngine.SendMessageOptions)arg2);
	}
	public static void UnityEngine__Component_SendMessage(UnityEngine.Component arg0, System.String arg1)
	{
		arg0.SendMessage(arg1);
	}
	public static void UnityEngine__Component_SendMessage(UnityEngine.Component arg0, System.String arg1, int arg2)
	{
		arg0.SendMessage(arg1, (UnityEngine.SendMessageOptions)arg2);
	}
	public static void UnityEngine__Component_BroadcastMessage(UnityEngine.Component arg0, System.String arg1)
	{
		arg0.BroadcastMessage(arg1);
	}
	public static void UnityEngine__Component_BroadcastMessage(UnityEngine.Component arg0, System.String arg1, int arg2)
	{
		arg0.BroadcastMessage(arg1, (UnityEngine.SendMessageOptions)arg2);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_position(UnityEngine.Transform obj)
	{
		return obj.position;
	}
	public static void UnityEngine__Transform_set_position(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.position = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_localPosition(UnityEngine.Transform obj)
	{
		return obj.localPosition;
	}
	public static void UnityEngine__Transform_set_localPosition(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.localPosition = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_eulerAngles(UnityEngine.Transform obj)
	{
		return obj.eulerAngles;
	}
	public static void UnityEngine__Transform_set_eulerAngles(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.eulerAngles = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_localEulerAngles(UnityEngine.Transform obj)
	{
		return obj.localEulerAngles;
	}
	public static void UnityEngine__Transform_set_localEulerAngles(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.localEulerAngles = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_right(UnityEngine.Transform obj)
	{
		return obj.right;
	}
	public static void UnityEngine__Transform_set_right(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.right = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_up(UnityEngine.Transform obj)
	{
		return obj.up;
	}
	public static void UnityEngine__Transform_set_up(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.up = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_forward(UnityEngine.Transform obj)
	{
		return obj.forward;
	}
	public static void UnityEngine__Transform_set_forward(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.forward = newv;
	}
	public static UnityEngine.Quaternion UnityEngine__Transform_get_rotation(UnityEngine.Transform obj)
	{
		return obj.rotation;
	}
	public static void UnityEngine__Transform_set_rotation(UnityEngine.Transform obj, UnityEngine.Quaternion newv)
	{
		obj.rotation = newv;
	}
	public static UnityEngine.Quaternion UnityEngine__Transform_get_localRotation(UnityEngine.Transform obj)
	{
		return obj.localRotation;
	}
	public static void UnityEngine__Transform_set_localRotation(UnityEngine.Transform obj, UnityEngine.Quaternion newv)
	{
		obj.localRotation = newv;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_localScale(UnityEngine.Transform obj)
	{
		return obj.localScale;
	}
	public static void UnityEngine__Transform_set_localScale(UnityEngine.Transform obj, UnityEngine.Vector3 newv)
	{
		obj.localScale = newv;
	}
	public static UnityEngine.Transform UnityEngine__Transform_get_parent(UnityEngine.Transform obj)
	{
		return obj.parent;
	}
	public static void UnityEngine__Transform_set_parent(UnityEngine.Transform obj, UnityEngine.Transform newv)
	{
		obj.parent = newv;
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Transform_get_worldToLocalMatrix(UnityEngine.Transform obj)
	{
		return obj.worldToLocalMatrix;
	}
	public static UnityEngine.Matrix4x4 UnityEngine__Transform_get_localToWorldMatrix(UnityEngine.Transform obj)
	{
		return obj.localToWorldMatrix;
	}
	public static UnityEngine.Transform UnityEngine__Transform_get_root(UnityEngine.Transform obj)
	{
		return obj.root;
	}
	public static System.Int32 UnityEngine__Transform_get_childCount(UnityEngine.Transform obj)
	{
		return obj.childCount;
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_get_lossyScale(UnityEngine.Transform obj)
	{
		return obj.lossyScale;
	}
	public static System.Boolean UnityEngine__Transform_get_hasChanged(UnityEngine.Transform obj)
	{
		return obj.hasChanged;
	}
	public static void UnityEngine__Transform_set_hasChanged(UnityEngine.Transform obj, System.Boolean newv)
	{
		obj.hasChanged = newv;
	}
	public static System.Int32 UnityEngine__Transform_get_hierarchyCapacity(UnityEngine.Transform obj)
	{
		return obj.hierarchyCapacity;
	}
	public static void UnityEngine__Transform_set_hierarchyCapacity(UnityEngine.Transform obj, System.Int32 newv)
	{
		obj.hierarchyCapacity = newv;
	}
	public static System.Int32 UnityEngine__Transform_get_hierarchyCount(UnityEngine.Transform obj)
	{
		return obj.hierarchyCount;
	}
	public static void UnityEngine__Transform_SetParent(UnityEngine.Transform arg0, UnityEngine.Transform arg1)
	{
		arg0.SetParent(arg1);
	}
	public static void UnityEngine__Transform_SetParent(UnityEngine.Transform arg0, UnityEngine.Transform arg1, System.Boolean arg2)
	{
		arg0.SetParent(arg1, arg2);
	}
	public static void UnityEngine__Transform_SetPositionAndRotation(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, UnityEngine.Quaternion arg2)
	{
		arg0.SetPositionAndRotation(arg1, arg2);
	}
	public static void UnityEngine__Transform_Translate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, int arg2)
	{
		arg0.Translate(arg1, (UnityEngine.Space)arg2);
	}
	public static void UnityEngine__Transform_Translate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		arg0.Translate(arg1);
	}
	public static void UnityEngine__Transform_Translate(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3, int arg4)
	{
		arg0.Translate(arg1, arg2, arg3, (UnityEngine.Space)arg4);
	}
	public static void UnityEngine__Transform_Translate(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		arg0.Translate(arg1, arg2, arg3);
	}
	public static void UnityEngine__Transform_Translate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, UnityEngine.Transform arg2)
	{
		arg0.Translate(arg1, arg2);
	}
	public static void UnityEngine__Transform_Translate(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3, UnityEngine.Transform arg4)
	{
		arg0.Translate(arg1, arg2, arg3, arg4);
	}
	public static void UnityEngine__Transform_Rotate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, int arg2)
	{
		arg0.Rotate(arg1, (UnityEngine.Space)arg2);
	}
	public static void UnityEngine__Transform_Rotate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		arg0.Rotate(arg1);
	}
	public static void UnityEngine__Transform_Rotate(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3, int arg4)
	{
		arg0.Rotate(arg1, arg2, arg3, (UnityEngine.Space)arg4);
	}
	public static void UnityEngine__Transform_Rotate(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		arg0.Rotate(arg1, arg2, arg3);
	}
	public static void UnityEngine__Transform_Rotate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, System.Single arg2, int arg3)
	{
		arg0.Rotate(arg1, arg2, (UnityEngine.Space)arg3);
	}
	public static void UnityEngine__Transform_Rotate(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, System.Single arg2)
	{
		arg0.Rotate(arg1, arg2);
	}
	public static void UnityEngine__Transform_RotateAround(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2, System.Single arg3)
	{
		arg0.RotateAround(arg1, arg2, arg3);
	}
	public static void UnityEngine__Transform_LookAt(UnityEngine.Transform arg0, UnityEngine.Transform arg1, UnityEngine.Vector3 arg2)
	{
		arg0.LookAt(arg1, arg2);
	}
	public static void UnityEngine__Transform_LookAt(UnityEngine.Transform arg0, UnityEngine.Transform arg1)
	{
		arg0.LookAt(arg1);
	}
	public static void UnityEngine__Transform_LookAt(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1, UnityEngine.Vector3 arg2)
	{
		arg0.LookAt(arg1, arg2);
	}
	public static void UnityEngine__Transform_LookAt(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		arg0.LookAt(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_TransformDirection(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.TransformDirection(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_TransformDirection(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return arg0.TransformDirection(arg1, arg2, arg3);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_InverseTransformDirection(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.InverseTransformDirection(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_InverseTransformDirection(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return arg0.InverseTransformDirection(arg1, arg2, arg3);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_TransformVector(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.TransformVector(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_TransformVector(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return arg0.TransformVector(arg1, arg2, arg3);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_InverseTransformVector(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.InverseTransformVector(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_InverseTransformVector(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return arg0.InverseTransformVector(arg1, arg2, arg3);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_TransformPoint(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.TransformPoint(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_TransformPoint(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return arg0.TransformPoint(arg1, arg2, arg3);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_InverseTransformPoint(UnityEngine.Transform arg0, UnityEngine.Vector3 arg1)
	{
		return arg0.InverseTransformPoint(arg1);
	}
	public static UnityEngine.Vector3 UnityEngine__Transform_InverseTransformPoint(UnityEngine.Transform arg0, System.Single arg1, System.Single arg2, System.Single arg3)
	{
		return arg0.InverseTransformPoint(arg1, arg2, arg3);
	}
	public static void UnityEngine__Transform_DetachChildren(UnityEngine.Transform arg0)
	{
		arg0.DetachChildren();
	}
	public static void UnityEngine__Transform_SetAsFirstSibling(UnityEngine.Transform arg0)
	{
		arg0.SetAsFirstSibling();
	}
	public static void UnityEngine__Transform_SetAsLastSibling(UnityEngine.Transform arg0)
	{
		arg0.SetAsLastSibling();
	}
	public static void UnityEngine__Transform_SetSiblingIndex(UnityEngine.Transform arg0, System.Int32 arg1)
	{
		arg0.SetSiblingIndex(arg1);
	}
	public static System.Int32 UnityEngine__Transform_GetSiblingIndex(UnityEngine.Transform arg0)
	{
		return arg0.GetSiblingIndex();
	}
	public static UnityEngine.Transform UnityEngine__Transform_Find(UnityEngine.Transform arg0, System.String arg1)
	{
		return arg0.Find(arg1);
	}
	public static System.Boolean UnityEngine__Transform_IsChildOf(UnityEngine.Transform arg0, UnityEngine.Transform arg1)
	{
		return arg0.IsChildOf(arg1);
	}
	public static UnityEngine.Transform UnityEngine__Transform_GetChild(UnityEngine.Transform arg0, System.Int32 arg1)
	{
		return arg0.GetChild(arg1);
	}

}
