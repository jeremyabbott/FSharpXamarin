namespace FSharpMeetupXamarinForms

open System
open System.IO
open Xamarin.Forms
open FSharpMeetupXamarinForms.Data
open FSharpMeetupXamarinForms.ViewBuilders

type App() = 
    inherit Application()

    let stack = StackLayout(VerticalOptions = LayoutOptions.Center)

    do
        //buildListView stack Takes twice as long. :/
        Async.StartImmediate <| buildListViewAsync stack
        base.MainPage <- ContentPage(Content = stack)