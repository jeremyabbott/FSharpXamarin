﻿namespace AutoLayoutExample

open System

open UIKit
open Foundation

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    override val Window = null with get, set

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        this.Window <- new UIWindow(UIScreen.MainScreen.Bounds)

        this.Window.RootViewController <- new ViewController()
        this.Window.MakeKeyAndVisible()

        true