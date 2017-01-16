Meringue
=========

Meringue 是用於開發 Unity 5.x 遊戲的公用程式庫，提供在遊戲中常用的共通元件。

現時的開發環境為 Unity 5.4.3 。

## 套件列表
### Localization
處理本地化、以及多語言切換的各種基礎設施。

* LanguageId：基於 [IETF Language Tag](https://en.wikipedia.org/wiki/IETF_language_tag) 的語言識別碼。 

### Mvp
實現 [Model-View-Presenter](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter) 架構範式。

本套件相依於 [UniRx](https://github.com/neuecc/UniRx) 程式庫，需要在專案設定中定義 `USE_UNI_RX`。

* Presenter：作為 presenter 物件的基底類別。
* Scene：對應於 Unity 的場景概念，以 stack 的形式來管理及顯示 views 。
* View：作為 view 物件的基底類別。
* ViewManager：管理在當前場景下已載入的 view 物件。

### Predef
Meringue 程式庫本身的預先定義常數。

* VersionNumber：程式庫的版本號。

### String
協助字串處理的元件。

* CaseInsensitive：不區分大小寫的字串類型基底類別。
* CaseInsensitiveString：不區分大小寫的字串。

----
(c) 2016 Slimek