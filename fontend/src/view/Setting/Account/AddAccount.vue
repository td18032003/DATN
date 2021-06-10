<template>
    <div>
        <cc-popup 
            v-model="value"
            :width="500"
            title="Thêm người dùng"
            @close="close">
            <cc-row>
                <cc-col w="40">
                    Tên người dùng
                </cc-col>
                <cc-col w="60">
                    <cc-select-box v-model="file.FileName"
                        :dataSource="employees"
                        valueField="employees"></cc-select-box>
                </cc-col>
            </cc-row>
            <cc-row>
                <cc-col w="40">
                    Vai trò
                </cc-col>
                <cc-col w="60">
                    <cc-select-box v-model="file.ParentID"
                        :dataSource="listFolder"
                        displayField="FileName"
                        valueField="FileID"></cc-select-box>
                </cc-col>
            </cc-row>
            <cc-row>
                <cc-col w="40">
                    Quyền truy cập dữ liệu
                </cc-col>
                <cc-col w="60">
                    <cc-input :height="72" v-model="file.Note"></cc-input>
                </cc-col>
            </cc-row>
            <div class="footer flex">
                <cc-button type="secondary-border" class="m-r-12" @click="close" :loading="loading">
                    Hủy
                </cc-button>
                <cc-button type="primary" @click="uploadFile" :loading="loading">
                    Lưu
                </cc-button>
            </div>
        </cc-popup>
    </div>
</template>
<script>
import FileAPI from '@/api/Components/FileAPI.js';
import EmployeeAPI from '../../../api/Components/EmployeeAPI';
export default {
    props: {
        value:{
            type: [String,Boolean],
            default: false
        },
        listFolder: {
            type: Array,
            default: () => []
        }
    },
    data(){
        return{
            file: {
                FileName: null,
                Note: null,
                TypeFile: "Folder",
                TenantID: null,
                CreatedBy: null
            },
            loading: false,
            employees : []
        }
    },
    methods: {
        close(){
            this.$emit("input",false);
        },
        uploadFile(){
            var me = this;
            this.file.TenantID = this.$store.getters.tenantID;
            this.file.CreatedBy = this.$store.getters.employeeID;
            this.loading = true;
            FileAPI.Insert(this.file).then(res => {
                me.loading = false;
                if(res.data && res.data.Success){
                    me.$emit("save",true);
                }
            });
        },
        async getAllEmployee(){
            var res = await EmployeeAPI.GetAll();
            if(res.data && res.data.Success){
                for(let  i = 0; i < res.data.Data.length; i++) {
                    this.employees.push(res.data.Data[i].EmployeeName)
                }
                console.log("employees", this.employees);

            }
        },
    },
    created() {
        this.getAllEmployee();
    }
}
</script>
<style lang="scss" scoped>
.chose-file{
    height: 300px;
    display: flex;
    align-items: center;
    justify-content: center;
}
.footer{
    float: right;
}
</style>