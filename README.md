# ARCraft_Exp

## Overview

This project is a trial production of a craft game to be done in AR.Developed using Unity and Google ARCore.

***

このプロジェクトは某クラフトゲームをARでやるために試しに作ってみたものです。UnityとGoogle ARCoreを利用して開発しました。

## Development environment

* MacBook Pro (13-inch, 2016)
* Unity 2019.1.1.f1 Personal
* ARCore 1.9.0
* Pixel 3 (Android 9.0 Pie)

## Requirement

An environment where you can create ARCore apps.Please check this ARCore official site  for details.  
(Please pay particular attention to whether your smartphone supports ARCore.)  
[ARCore Unity for Android](https://developers.google.com/ar/develop/unity/quickstart-android)

***

ARCoreのアプリケーションを開発できる環境と動作するデバイスが必要です。詳しくは、ARCoreの公式サイトをご覧ください。
(ご使用のスマートフォンがARCoreをサポートしているかについて、特に注目してください。)  
[ARCore Unity for Android](https://developers.google.com/ar/develop/unity/quickstart-android)

## SetUp

1. Download this project.
2. Open the downloaded project in Unity.
3. Download the UnityPackage from [ARCore SDK for Unity 1.9.0](https://github.com/google-ar/arcore-unity-sdk/releases).
4. Import the downloaded ARCore UnityPackage.
5. If you are using Unity 2019.x, install "Multiplayer HLAPI" and "XR Legacy Input Helper" from Window> PackageManager.
6. Open Assets> Gitogito> Scenes> Main in the Project view.

You are now ready to build!  
(Sorry,,,please check Android build by yourself.)

***

1. このプロジェクトをダウンロードする。
2. ダウンロードしたプロジェクトをUnityで開く。
3. [ARCore SDK for Unity 1.9.0](https://github.com/google-ar/arcore-unity-sdk/releases)のUnityPackageをダウンロードする。
4. ダウンロードしたARCoreのUnityPackageをインポートする。
5. Unity 2019.xを利用している方は、Window>PackageManagerから"Multiplayer HLAPI"と"XR Legacy Input Helper"をインストールする。
6. ProjectビューのAssets>Gitogito>Scenes>Mainを開く。

これでビルドできるようになります！  
(Androidビルドは自分で調べてください...)

## Usage

1. Once built, launch the app.
2. There is a type of block color at the bottom of the screen. Touch to select. (You can scroll to the side.)
3. If you tap a place that is not a block selection, if there is a floor or wall where you tap, you can place the block you are selecting. (Can not be placed where ARCore can not recognize)
  
\* The area recognized by ARCore is not displayed by default for appearance. If you want to make it easy to identify the part that can be placed, change the material of Assets> Prefabs> ARPlane to Assets> GoogleARCore> Examples> Common> Materials> PlaneGrid etc.

***

1. ビルドしたら、アプリを起動する。
2. 画面下部にブロックの色の種類がある。タッチすると選択される。(横にスクロールできます。)
3. ブロック選択ではないところをタップすると、タップしたところに床か壁があると、選択中のブロックを置ける。(ARCoreが認識できていないところには置けません)

※ 見た目のために、ARCoreが認識できている範囲はデフォルトでは表示していません。置ける部分を分かりやすくしたい場合は、Assets>Prefabs>ARPlaneのマテリアルをAssets>GoogleARCore>Examples>Common>Materials>PlaneGridなどに変更してください。

## License

This project is released under the Apache License Version 2.0, see [LICENSE](https://github.com/BushCloversHigh/ARCraft_Exp/blob/master/LICENSE).

***

このプロジェクトはApache License Version 2.0のオープンソースライセンスの元公開しています。詳しくは[LICENSE](https://github.com/BushCloversHigh/ARCraft_Exp/blob/master/LICENSE)をみてください。

## Authors

Geatnium ([Twitter](https://twitter.com/geatnium))

## References

* ARCore, Google, https://developers.google.com/ar/ (2019/5/19)
* ARCoreを簡単にUnityで始める, Qiita, https://qiita.com/norihirosunada/items/4fad091c152249fe53f1 (2019/5/19)
