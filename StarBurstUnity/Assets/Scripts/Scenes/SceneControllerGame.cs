using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SceneControllerGame : SceneController_Base 
{
#region inspector hooks

	public UnityEngine.UI.Text versionText;
	public float delay = 2f;

	public float buttonPanelTweenDurn = 0.5f;

	public RectTransform buttonPanelRT;
	public UnityEngine.UI.Image showButtonPanelImage;

	#endregion inspector hooks

	private void MoveOn()
	{
		HideButtonPanel( );
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
		
		Invoke( "MoveOn", delay );
	}

	#endregion SceneController_Base

	void ShowButtonPanel( )
	{
		ShowVersionText( );
		Sequence sequence = DOTween.Sequence( );
		showButtonPanelImage.color = showButtonPanelImage.color.Alphaed( 1f );
		sequence.Append( showButtonPanelImage.DOColor( showButtonPanelImage.color.Alphaed( 0f ), buttonPanelTweenDurn/2f ));

		sequence.Append(buttonPanelRT.DOAnchorPosX( 0f, buttonPanelTweenDurn ).SetEase( Ease.InOutQuad ));
		sequence.Join(versionText.DOColor( versionText.color.Alphaed(1f), buttonPanelTweenDurn ));
	}

	void HideButtonPanel( )
	{
		Sequence sequence = DOTween.Sequence( );
		showButtonPanelImage.color = showButtonPanelImage.color.Alphaed( 0f );
		sequence.Append(buttonPanelRT.DOAnchorPosX( 60f, buttonPanelTweenDurn ).SetEase( Ease.InOutQuad ).OnComplete( HideVersionText));
		sequence.Append( showButtonPanelImage.DOColor( showButtonPanelImage.color.Alphaed( 1f ), buttonPanelTweenDurn/2f ) );

		versionText.DOColor( versionText.color.Alphaed( 0f ), buttonPanelTweenDurn );
	}

	public void HandleShowButtonPanelButtonClick( )
	{
		ShowButtonPanel( );
	}

	public void HandleHideButtonPanelButtonClick( )
	{
		HideButtonPanel( );
	}

	public void HandleQuitButtonClick( )
	{
		Application.Quit( );
	}

	private void ShowVersionText( )
	{
		ShowVersionText( true );
	}

	private void HideVersionText( )
	{
		ShowVersionText( false);
	}

	private void ShowVersionText(bool b)
	{
		versionText.gameObject.SetActive( b );
	}
}
