import { AfterViewInit, Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-dialog-confirmation',
  templateUrl: './dialog-confirmation.component.html',
  styleUrls: ['./dialog-confirmation.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DialogConfirmationComponent implements OnInit, AfterViewInit {

  title: string = '';
  message: string = ''
  style: any = {};
  loading: boolean = true;
  timer: number = 0;
  singleButton: string;

  constructor(
    public dialogRef: MatDialogRef<DialogConfirmationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {

    if (data != null && typeof data === 'object') {
      this.title = data.title;
      this.message = data.message;
      this.singleButton = data.singleButton;

      if (data.style != null && typeof data.style !== 'undefined') {
        this.style = data.style;
      }

      if (data.timerloading != null && typeof data.timerloading !== 'undefined') {
        this.timer = data.timerloading;
      }

    }
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    setTimeout(() => this.loading = false, this.timer);
  }

  confirm() {
    this.dialogRef.close(true);
  }

  cancel() {
    this.dialogRef.close(false);
  }

}
