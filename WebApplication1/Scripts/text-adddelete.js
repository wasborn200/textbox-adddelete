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
        var inputid = 'input' + number;

        // 項目を非表示にする
        var inputfieldname = document.getElementById(inputfieldid);
        inputfieldname.style.display = "none";


        // 削除した項目のみ値を削除する
        document.getElementById(inputid).value = '';

        // 全項目の文字を取得する
        var values = [];
        for (var i = 1; i <= 4; i++) {
            var itemId = "input" + i;
            var input_message = document.getElementById(itemId).value;
            if (!(input_message == "")) {
                values.push(input_message);
            }
        };

        // 最初のinputから順番に値を再配置してする
        // inputfieldの総数-1の数までループ
        // 最後まで""で埋めないと、valueにundefinedと入力されてしまう。
        for (var number = 0, item = 1; number <= 3; number++, item++) {
            var itemId = "input" + item;
            if (values[number] == null) {
                document.getElementById(itemId).value = "";
            } else {
                document.getElementById(itemId).value = values[number];
            }
        };

        var output_message = "";
        for (var i = 0; i < values.length; i++) {
            if (!(output_message == "")) {
                output_message = output_message + " , " + values[i];
            };
        }
        document.getElementById("output_message").innerHTML = output_message;
    }
}