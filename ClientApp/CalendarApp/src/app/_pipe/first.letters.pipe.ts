import { Pipe, PipeTransform } from '@angular/core';


@Pipe({
  name: 'firstLetters'
})
export class FirstLettersPipe implements PipeTransform {
  transform(value: string, args: any[]): string {
    let returnStr = "";
    if (value === null) return "";
    for (var i = 0; i < value.split(' ').length; i++) {
      returnStr += value.split(' ')[i].charAt(0)
    }
    return returnStr.toUpperCase();
  }

}
