namespace AutoLayoutExample

open System

open CoreGraphics
open Foundation
open UIKit
open Praeclarum.AutoLayout
open AutoLayoutExample.Utilities

[<Register ("ViewController")>]
type ViewController () =
    inherit UIViewController()

    override x.DidReceiveMemoryWarning () =
        // Releases the view if it doesn't have a superview.
        base.DidReceiveMemoryWarning ()
        // Release any cached data, images, etc that aren't in use.

    override x.ViewDidLoad () =
        base.ViewDidLoad ()
        let twenty = nfloat 20.
        let fifty = nfloat 50.

        let label = new UILabel(Text = "Hello AutoLayout Constraints", TextColor = UIColor.Red, TextAlignment = UITextAlignment.Center)
        label.Layer.BorderColor <- UIColor.Blue.CGColor
        label.Layer.BorderWidth <- nfloat 1.

        let textfield = new UITextField()
        textfield.Layer.BorderColor <- UIColor.Green.CGColor
        textfield.Layer.BorderWidth <- nfloat 1.

        let view = new UIView(BackgroundColor = UIColor.White)
        view.AddSubviews(label, textfield)

        // This function is so important because otherwise autoresizing masks. :(
        addConstraints view [|
            label.LayoutTop == view.LayoutTop + twenty
            label.LayoutLeft == view.LayoutLeft + twenty
            label.LayoutRight == view.LayoutCenterX - (nfloat 10.)

            textfield.LayoutTop == view.LayoutTop + twenty
            textfield.LayoutLeft == view.LayoutCenterX + (nfloat 10.)
            textfield.LayoutRight == view.LayoutRight - twenty |]

        x.View <- view
        // Perform any additional setup after loading the view, typically from a nib.

    override x.ShouldAutorotateToInterfaceOrientation (toInterfaceOrientation) =
        // Return true for supported orientations
        if UIDevice.CurrentDevice.UserInterfaceIdiom = UIUserInterfaceIdiom.Phone then
           toInterfaceOrientation <> UIInterfaceOrientation.PortraitUpsideDown
        else
           true

