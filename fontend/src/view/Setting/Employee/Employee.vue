<template>
    <div class="employee-view">
        <div v-if="!showDetail" style="height: 100%">
            <div class="header">
                <div>
                    <span class="title">Danh sách nhân viên</span>
                </div>
                <div class="flex">
                    <cc-input class="m-r-12" width="250px" icon="icon-search" placeholderInput="Tìm kiếm nhân viên"></cc-input>
                    <cc-button type="primary " icon="icon-plus-white" @click="openAdd">Thêm</cc-button>
                </div>
            </div>
            <div class="view-table">
                <ccTable 
                    :listHeader="listHeader" 
                    :dataSource="dataSource"
                    @clickEdit="openEdit"
                    @clickDelete="confirmDelete">
                </ccTable>
            </div>
        </div>
        <AddEmployee v-if="showDetail" @close="closeForm"></AddEmployee>
    </div>
</template>
<script>
import AddEmployee from "./AddEmployee.vue";
import EmployeeAPI from "@/api/Components/EmployeeAPI.js"
export default {
    components: {
        AddEmployee
    },
    data(){
        return{
            dataSource: [],
            listHeader: [
                {
                    DataField: "EmployeeCode",
                    Caption: "Mã nhân viên",
                    DataTyle: "text",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "EmployeeName",
                    Caption: "Tên nhân viên",
                    DataTyle: "text",
                    Fixed: true,
                    MinWidth: 150
                },
                {
                    DataField: "OrganizationUnitName",
                    Caption: "Đơn vị",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "JobPoisionName",
                    Caption: "Chức vụ",
                    DataTyle: "date",
                    MinWidth: 150
                },
                {
                    DataField: "BirthDay",
                    Caption: "Ngày sinh",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Gender",
                    Caption: "Giới tính",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Phone",
                    Caption: "SĐT",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Email",
                    Caption: "Email",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Status",
                    Caption: "Trạng thái",
                    DataTyle: "text",
                    MinWidth: 150
                }
            ],
            showDetail: false
        }
    },
    async created() {
        await this.getAll();
    },
    methods: {
        openAdd(){
            this.showDetail = true;
        },
        closeForm(){
            this.showDetail = false;
        },
        async getAll(){
        var res = await EmployeeAPI.GetAll();
        if(res.data && res.data.Success){
            this.dataSource = res.data.Data;
            console.log("employees", res.data.Data);
        }
    }
    }
}
</script>
<style lang="scss" scoped>
.employee-view{
    height: 100%;
    .header{
        display: flex;
        align-items: center;
        padding: 0 0 12px 0;
        justify-content: space-between;
        .title{
            font-size: 18px;
            font-weight: 500;
        }
    }
    .view-table{
        height: calc(100% - 60px);
    }
}
</style>