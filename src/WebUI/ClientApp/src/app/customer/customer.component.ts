import { Component, TemplateRef } from '@angular/core';
import { CustomersClient, CreateCustomerCommand, CustomerDto, UpdateCustomerCommand, PaginatedListOfCustomerDto } from '../web-api-client';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-customer-component',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss']
})
export class CustomerComponent {

    debug = false;
    vm = PaginatedListOfCustomerDto;
    selected: CustomerDto;

    newListEditor: any = {};
    listOptionsEditor: any = {};
    DetailsEditor: any = {};

    newListModalRef: BsModalRef;
    listOptionsModalRef: BsModalRef;
    deleteListModalRef: BsModalRef;
    DetailsModalRef: BsModalRef;

    faPlus = faPlus;
    faEllipsisH = faEllipsisH;

    constructor(private client: CustomersClient, private sClient: CustomersClient, private modalService: BsModalService) {
        client.getCustomersWithPagination(1,10).subscribe(
            result => {
                this.vm = result;
            },
            error => console.error(error)
        );
    }

    add() {
        let customer = CustomerDto.fromJS({
            id: 0,
            prefix: '',
            firstName: '',
            secondName: '',
            lastName: '',
            secondLastName: '',
            suffix: '',
            idNumber: '',
            genderId: 0,
            maritalStatusId: 0,
            identificationTypeId: 0,
            fullName: ''
        });

        this.edit(customer, 'Title');
    }

    edit(customer: CustomerDto, inputId: string): void {
        this.selected = customer;
        setTimeout(() => document.getElementById(inputId).focus(), 100);
    }

    update(customer: CustomerDto, pressedEnter: boolean = false): void {
        let isNew = customer.id == 0;

        if (!customer.firstName.trim()) {
            this.delete(customer);
            return;
        }

        if (customer.id == 0) {
            this.sClient.create(CreateCustomerCommand.fromJS({ ...customer, listId: this.selectedList.id }))
                .subscribe(
                    result => {
                      customer.id = result;
                    },
                    error => console.error(error)
                );
        } else {
            this.sClient.update(customer.id, UpdateCustomerCommand.fromJS(customer))
                .subscribe(
                    () => console.log('Update succeeded.'),
                    error => console.error(error)
                );
        }

        this.selected = null;

        if (isNew && pressedEnter) {
            this.add();
        }
    }

    // Delete
    delete(customer: CustomerDto) {

    }
}
