using UnityEngine;
using System.Collections;

public class SceneControllerBootstrap : SceneController_Base 
{
#region inspector hooks

	public UnityEngine.UI.Text versionText;
	public float delay = 2f;

#endregion inspector hooks

	private void MoveOn()
	{
		RJWard.Core.RWSceneManager.Instance.SwitchScene( RJWard.Core.RWSceneManager.EScene.Game);
	}

#region event handlers


#endregion event handlers

#region SceneController_Base

	override public RJWard.Core.RWSceneManager.EScene Scene ()
	{
		return RJWard.Core.RWSceneManager.EScene.Bootstrap;
	}

	override protected void PostStart()
	{
		Application.targetFrameRate = 60;

		versionText.text = RJWard.Core.Version.versionNumber.DebugDescribe ();
		Invoke( "MoveOn", delay );
	}

	#endregion SceneController_Base

}
