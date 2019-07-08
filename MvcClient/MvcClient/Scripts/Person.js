//MvcSamplesモジュールの定義
var MvcSamples;
(function (MvcSamples) {
    //Personクラスの定義
    var Person = /** @class */ (function () {
        //コンストラクター
        function Person(name, birth) {
            this.name = name;
            this.birth = birth;
        }
        //toStringメソッドの定義
        Person.prototype.toString = function () {
            return this.name + " " + this.birth.toLocaleDateString();
        };
        return Person;
    }());
    MvcSamples.Person = Person;
})(MvcSamples || (MvcSamples = {}));
var p = new MvcSamples.Person("山田リオ", new Date(2009, 5, 25));
window.alert(p.toString());
//# sourceMappingURL=Person.js.map