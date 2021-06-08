<template>
    <div class="employee-view">
        <div style="height: 100%">
            <div class="header">
                <div>
                    <span class="title">Danh sách người dùng</span>
                </div>
                <div class="flex">
                    <cc-input class="m-r-12" width="250px" icon="icon-search" placeholderInput="Tìm kiếm người dùng"></cc-input>
                    <cc-button type="primary" icon="icon-plus-white" @click="openAdd">Thêm</cc-button>
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
        <AddAccount v-if="activePopup" v-model="activePopup"></AddAccount>
    </div>
</template>
<script>
import AddAccount from "./AddAccount.vue";
export default {
    components: {
        AddAccount
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
                    DataField: "Email",
                    Caption: "Email",
                    DataTyle: "text",
                    MinWidth: 150
                },
                {
                    DataField: "Password",
                    Caption: "Mật khẩu",
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
            activePopup: false
        }
    },
    methods: {
        openAdd(){
            this.activePopup = true;
        },
        closeForm(){
            this.activePopup = false;
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