# Shader_Parts

##操作方法
拡大縮小 : スクロール
移動 : WDSA or カーソルキー
ノード消去 : ノードをドラックしながらデリートキー

##使い方
1.  ゲームシーンを右クリックor「N」押しで何のノードを生成するか選択する。
2.  パイプラインを繋ぐ
3.  最後に、エクスポートシェーダーノードを生成してエクスポートボタンを押す。

##拡張の仕方
*   新しいノードの作り方
    1.  Node_Baseを継承する
    2.  設定が必出な変数
        *   VariableName : ノードの名前
        *   exporter[].VariableName : 実行結果を格納する変数名
        *   actionString : シェーダーで実際に書く内容
    2.  Assets/Resources/Prefab/Node/ にプレハブを置く