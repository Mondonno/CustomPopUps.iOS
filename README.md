<p align="center">
  <img width="199" height="199" src="https://i.imgur.com/32FqQY0.png" alt="smartphone">
</p>

# CustomPopUps.iOS

A simple yet powerful library for creating and customizing created popups in Xamarin.iOS framework.

> **Note**<br>
> Beacause of the fact that Microsoft is depreacting Xamarin as 2022<br>
> we will add a support for new MAUI, If it will be necesarry.

You might have thought in the past: is there any great yet simple library to make custom popups in Xamarin.IOS and animate them?<br>
Well, you've just found it!

## Features 

- Automatically exiting popup after click outside of it
- Easily passing windows and contexts into it
- Beautiful, and customizable animations
- Ability to listen on the popup events like show and close
- Using only Xamarin libraries (built-in), no 3rd party libraries involved

## Usage

- Clone the project using Git<br>
- Add `using CPopupLibrary` on the top of your `.cs` file where you want to use custom popups
- Now just add some code at `YourCustomizePopup.cs` in `YourPopUpCode` Method
- Create `YourCustomizePopup` object like this:<br>
```csharp
YourCustomizePopup popup = new YourCustomizePopup();
```
- Show it over the world
```csharp
await popup.ShowPopUp();
```

### See how it looks in action
![A gif demonstrating how the library works](https://i.imgur.com/tpLGIic.gif)

### Credits

- [**@BartekPacia**](https://github.com/bartekpacia), for reviews
- [**@AlancLiu**](https://stackoverflow.com/users/6228063/alanc-liu), for idea and insipration
