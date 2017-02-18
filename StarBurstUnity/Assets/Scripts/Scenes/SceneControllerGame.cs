using UnityEngine;
using System.Collections;

public class SceneControllerGame : SceneController_Base 
{
#region inspector hooks

	public UnityEngine.UI.Text versionText;
	public float delay = 2f;

	public GameObject buttonPanel;

	#endregion inspector hooks

	private void MoveOn()
	{
	}

#region event handlers

	#endregion event handlers

	#region SceneController_Base

	override public RJWard.Core.RWSceneManager.EScene Scene ()
	{
		return RJWard.Core.RWSceneManager.EScene.Game;
	}

	override protected void PostStart()
	{
		versionText.text = RJWard.Core.Version.versionNumber.DebugDescribe ();

		buttonPanel.gameObject.SetActive( false );

		Invoke( "MoveOn", delay );
	}

	#endregion SceneController_Base

}
