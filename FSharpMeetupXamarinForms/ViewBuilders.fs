module FSharpMeetupXamarinForms.ViewBuilders

open System
open Xamarin.Forms
open FSharpMeetupXamarinForms.Data

let bindListView(pokemon : PokemonDetail seq) (parent : StackLayout) (startTime : DateTime) =
    let template = DataTemplate(typeof<ImageCell>)
    let listView = ListView(ItemsSource = pokemon)
    template.SetBinding(ImageCell.TextProperty, "Name")
    template.SetBinding(ImageCell.ImageSourceProperty, "ImgUrl")
    listView.ItemTemplate <- template
    let endTime = DateTime.Now - startTime
    let label = new Label()
    label.Text <- endTime.TotalSeconds.ToString()

    do
        parent.Children.Add(label)
        parent.Children.Add(listView)

let buildListView (parent : StackLayout) =
    let startTime = DateTime.Now
    let p =
        getPokemon()
        |> Array.toSeq
        |> Seq.map(fun p -> getPokemonDetail p.Url)

    bindListView p parent startTime

let buildListViewAsync (parent : StackLayout) = async {
    let startTime = DateTime.Now
    let workflow =
        getPokemon()
        |> Array.toSeq
        |> Seq.map(fun p -> getPokemonDetailAsync p.Url)
        |> Async.Parallel

    Async.StartWithContinuations(
         workflow,
         (fun pokemon ->
             bindListView pokemon parent startTime),
         (fun _ -> ()),
         (fun _ -> ()))
}