$.validator.addMethod('blackword',
    function (value, element, param) {
        //入力値が空の場合は検証をスキップ(無条件で成功)
        value = $.trim(value);
        if (value === '') { return true; }

        //カンマ区切りテキストを分解し、入力値valueと順に比較
        var list = param.split(',');
        for (var i = 0, len = list.length; i < len; i++) {
            if (value.indexOf(list[i]) !== -1) {
                return false;
            }
        }
        return true;
    });

//blackword検証と、パラメータoptsを登録
$.validator.unobtrusive.adapters.addSingleVal('blackword', 'opts');