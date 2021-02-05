import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  public message = "a";
  public incrementCounter() {
    alert(this.message);
    this.currentCount++;
  }
}
