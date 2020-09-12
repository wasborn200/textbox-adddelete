// すでに資格データがある際のinputfield表示条件について
// var count = @Model.Count;
// コントローラーでinput1～10のどこまでデータがあるかでcountを決定。
// それをviewモデルを通じてjavascriptへ伝達
// 初期表示時にデータがある箇所までinputfieldをopenの状態にする

var count = 2;

function clickBtn1() {

    var inputfieldId = 'inputfield' + count;
    var inputfieIdName = document.getElementById(inputfieldId);
    inputfieIdName.style.display = "flex";
    count++;
}


function clickBtn2(number) {

    if (count >= 3) {
        count--;
        var inputfieldid = 'inputfield' + count;
        var sinputid = 'input' + number;
        var smmid = 'mm' + number;

        // 項目を非表示にする
        var inputfieldname = document.getElementById(inputfieldid);
        inputfieldname.style.display = "none";

        // 削除した項目のみ値を削除する
        document.getElementById(sinputid).value = '';
        document.getElementById(smmid).value = '';

        // 全項目の文字を取得する
        var input_values = [];
        var mm_values = [];
        for (var i = 1; i <= 4; i++) {
            var inputId = "input" + i;
            var mmId = "mm" + i;
            var old_input = document.getElementById(inputId).value;
            var old_mm = document.getElementById(mmId).value;
            if (!(old_input == "")) {
                input_values.push(old_input);
            }
            if (!(old_mm == "")) {
                mm_values.push(old_mm);
            }
        };

        // 最初のinputから順番に値を再配置してする
        // inputfieldの総数-1の数までループ
        // 最後まで""で埋めないと、valueにundefinedと入力されてしまう。
        for (var number = 0, item = 1; number <= 3; number++, item++) {
            var inputId = "input" + item;
            var mmId = "mm" + item;
            if (input_values[number] == null) {
                document.getElementById(inputId).value = "";
            } else {
                document.getElementById(inputId).value = input_values[number];
            }
            if (mm_values[number] == null) {
                document.getElementById(mmId).value = "";
            } else {
                document.getElementById(mmId).value = mm_values[number];
            }
        };

    }
}