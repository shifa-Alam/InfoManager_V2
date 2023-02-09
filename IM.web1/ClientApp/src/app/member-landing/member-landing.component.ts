import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MemberAddComponent } from '../member-add/member-add.component';
import { MemberDetailsComponent } from '../member-details/member-details.component';
import { Member } from '../Models/member';
import { MemberService } from '../services/member.service';

@Component({
  selector: 'app-member-landing',
  templateUrl: './member-landing.component.html',
  styleUrls: ['./member-landing.component.css']
})
export class MemberLandingComponent implements OnInit {
  dataSource!: MatTableDataSource<Member>;
  displayedColumns: string[] = [];
  isLoading: boolean = false;
  
  totalRecords: number = 0;
  constructor(private service: MemberService, public dialog: MatDialog) {

  }
  ngOnInit(): void {
    this.setColumn();
    this.getMembers();
  }
  setColumn() {
    this.displayedColumns = ['id', 'name', 'countryName', 'cityName','languageSkills','dateOfBirth','resume',  'actions'];
  }
  
  add() {
    const dialogRef = this.dialog.open(MemberAddComponent, {
      position: { top: '100px' },
      data: {
        member: new Member()
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getMembers();
    });
  }
  edit(member: any) {
    const dialogRef = this.dialog.open(MemberAddComponent, {
      position: { top: '100px' },
      data: {
        member: member
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getMembers();
    });

  }
  details(member: any) {
    const dialogRef = this.dialog.open(MemberDetailsComponent, {
      position: { top: '100px' },
      data: {
        member: member
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      // this.getMembers();
    });

  }

  delete(id: number) {
    if (id) {
      const dialogRef = this.dialog.open(DeleteDialogComponent, {
        position: { top: '10px' },
        // width:'20%'
      });

      dialogRef.afterClosed().subscribe(result => {

        if (result) {
          this.service.deleteMember(id).subscribe(result => {
            this.getMembers();
          },
            error => console.error(error));
        }
      });
    }
  }
 
  getMembers() {
    this.isLoading = true;
    this.service.getMember().subscribe(result => {
      // this.totalRecords = result.totalItemCount;
      console.log(result);
      this.dataSource = new MatTableDataSource(result);
      this.isLoading = false;
    },
      error => {
        this.dataSource = new MatTableDataSource();
        this.isLoading = false;
      }
    );
  }


}
