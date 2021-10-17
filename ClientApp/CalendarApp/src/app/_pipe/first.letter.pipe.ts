import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'firstLetter'
})
export class FirstLetterPipe implements PipeTransform {
  transform(value: string, args: any[]): string {
    if (value === null) return "";
    return value.charAt(0).toUpperCase();
  }

}
