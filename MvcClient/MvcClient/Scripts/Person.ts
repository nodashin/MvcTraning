//MvcSamplesモジュールの定義
module MvcSamples {

    //Personクラスの定義
    export class Person {

        //コンストラクター
        constructor(private name: string, private birth: Date) { }

        //toStringメソッドの定義
        public toString(): string {
            return this.name + " " + this.birth.toLocaleDateString();
        }
    }
}

var p = new MvcSamples.Person("山田リオ", new Date(2009, 5, 25));
window.alert(p.toString());