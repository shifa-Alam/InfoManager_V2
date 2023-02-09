import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Member } from '../Models/member';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {
  member: Member = new Member();
  constructor( public dialogRef: MatDialogRef<MemberDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      member: Member
    }
  ) {
    Object.assign(this.member, data.member);
  }

  ngOnInit(): void {
    this.dialogRef.updateSize('75%')
  }

}
