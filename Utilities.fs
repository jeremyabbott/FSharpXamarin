module AutoLayoutExample.Utilities

open System
open UIKit


let addConstraints (view : UIView) constraints =
    view.AddConstraints constraints 
    view.Subviews
    |> Array.iter (fun (v : UIView) -> v.TranslatesAutoresizingMaskIntoConstraints <- false)
