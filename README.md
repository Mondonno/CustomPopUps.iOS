<p align="center">
  <img width="199" height="199" src="https://i.imgur.com/32FqQY0.png" alt="smartphone">
</p>

# CustomPopUps.iOS
## Custom popups examples/library for Xamarin.iOS framework.

You might have thought in the past: is there any great yet simple library to make custom popups in Xamarin.IOS and animate then? Well, you've just found it!

## How to use?

**1.** 🚀 Download <a target="_blank" href="https://github.com/Mondonno/CustomPopUps.iOS/blob/master/CPopUpLibrary/Downloads/CPopupLibraryDEMO.iOS.zip?raw=true">`CPopupLibrary`</a> folder from our repository and add it to your Xamarin project (or you can use [**GitZip**](http://kinolien.github.io/gitzip/))<br><br>
**2.** 🛰 Add `using CPopupLibrary` on the top of your `.cs` file where you want to use custom popups<br><br>
**3.** 😍 Now just add some code at `YourCustomizePopup.cs` in `YourPopUpCode` Method<br><br>
**4.** 😎 Create `YourCustomizePopup` object like this:<br><br>

```csharp
YourCustomizePopup popup = new YourCustomizePopup();
```

**5.** 😱 Show the popup!<br>

```csharp
await popup.ShowPopUp();
```

**6.** 👍 That's it!<br><br>
![A gif demonstrating how the library works](https://i.imgur.com/tpLGIic.gif)

## Coming soon...

- [ ] Add the library to NuGet
- [x] Add more personalized customization options! 80/70%
- [ ] Add to choose more graphics libs (You can make popup using the eg. Skia Sharp )
- [ ] Add more cool animations! 🎉
- [ ] Add the project Wiki!

## Depends on

- **.NET CoreGraphics** | For animations<br>

## Credits

- [**@BartekPacia**](https://github.com/bartekpacia) | For reviews
- [**@AlancLiu**](https://stackoverflow.com/users/6228063/alanc-liu) | For Idea

## ⚠️ Warning ⚠️

This is the alpha/demo version of the library!<br>
If you encounter any problems, please create a new Issue in the [**Issues Tab**](https://github.com/Mondonno/CustomPopUps.iOS/issues)
