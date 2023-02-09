
import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable, ReplaySubject } from 'rxjs';
import { City } from '../Models/city';
import { Country } from '../Models/country';
import { Member } from '../Models/member';
import { MemberSkill } from '../Models/memberSkill';
import { Skill } from '../Models/skill';
import { MemberService } from '../services/member.service';
export interface memberFormGroup {
  name: FormControl<string>;
  countryId: FormControl<number>;
  cityId: FormControl<number>;
  dateOfBirth: FormControl<any>;//? makes controls as optional
}
@Component({
  selector: 'app-member-add',
  templateUrl: './member-add.component.html',
  styleUrls: ['./member-add.component.css']
})
export class MemberAddComponent implements OnInit {
  fileToUpload: File | null = null;
  member: Member = new Member();
  memberForm!: FormGroup<memberFormGroup>;
  isLoading: boolean = false;
  countries: Country[] = [];
  cities: City[] = [];
  skills: Skill[] = [];
  dummySkill: Skill[] = [];
  selectedCountryId: number = 0;
  selectedFile: any;

  constructor(
    public service: MemberService,
    public fb: FormBuilder,
    public dialogRef: MatDialogRef<MemberAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      member: Member
    }
  ) {
    Object.assign(this.member, data.member);
  }
  ngOnInit(): void {
    this.dialogRef.updateSize('75%')
    this.getCountries();
    this.getSkills();

    if (this.member.id) {
      this.getCities(this.member.countryId);
    }
    this.createMemberForm();
    this.setValue();
  }
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    this.member.resume = window.URL.createObjectURL(this.selectedFile) as string;

  }

  createMemberForm() {
    this.memberForm = new FormGroup<memberFormGroup>({
      name: new FormControl<string>('', { nonNullable: true, validators: [Validators.required] }),
      countryId: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      cityId: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      dateOfBirth: new FormControl<any>('', { nonNullable: true, validators: [Validators.required] }),
      // skills: new FormControl<any>('',{ nonNullable: true, validators: [Validators.required] })
    });
  }
  setValue() {
    if (this.member) {
      this.memberForm.patchValue({
        name: this.member.name,
        cityId: this.member.cityId,
        countryId: this.member.countryId,
        dateOfBirth: this.member.dateOfBirth
      })
    }
  }

  cancel() {
    this.dialogRef.close();
  }
  submit() {
    this.member.name = this.memberForm.value.name as string;
    this.member.cityId = this.memberForm.value.cityId as number;
    this.member.countryId = this.memberForm.value.countryId as number;
    this.member.dateOfBirth = this.memberForm.value.dateOfBirth as any;


    if (this.member.id) {
      this.service.updateMember(this.member).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));

    } else {
      this.service.saveMember(this.member).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));

    }

  }
  onCountrySelect(e: any) {
    if (e.value)
      this.getCities(e.value);
  }

  getCountries() {
    this.isLoading = true;
    this.service.getCountries().subscribe(result => {
      this.countries = result;
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }
  getSkills() {
    this.isLoading = true;
    this.service.getSkills().subscribe(result => {
      this.skills = result;
      this.memberSkillUpdate();
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

  memberSkillUpdate() {
    if (this.member.id == 0) {
      
      this.skills.forEach(element => {
        var memberSkill: MemberSkill = new MemberSkill();
        memberSkill.skillId = element.id;
        memberSkill.skillName = element.name;
        memberSkill.isSelect = false;
        this.member.memberSkills.push(memberSkill);
      });
    } else {
      this.skills.forEach(e => {
        if (this.member.memberSkills.find(x => (x.skillId == e.id))) {

        } else {
          this.dummySkill.push(e);
        }
       
      });

      this.dummySkill.forEach(element => {
        var memberSkill = new MemberSkill();
        memberSkill.skillId = element.id;
        memberSkill.skillName = element.name;
        memberSkill.isSelect = false;
        this.member.memberSkills.push(memberSkill);
      });
    }

  }

  getCities(countryId: number) {
    this.isLoading = true;
    this.service.getCities(countryId).subscribe(result => {
      this.cities = result;
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }
}

