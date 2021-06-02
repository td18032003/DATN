<template>
    <div>
        <cc-popup 
            v-model="value"
            :width="500"
            title="Thông tin tệp"
            @close="close">
            <cc-row>
                <cc-col w="40">
                    Chọn tệp từ
                </cc-col>
                <cc-col w="60">
                    <cc-radio :dataSource="optionFiles" v-model="optionValue"></cc-radio>
                </cc-col>
            </cc-row>
            <cc-row>
                <cc-col w="40">
                    Tên tệp
                </cc-col>
                <cc-col w="60">
                    <cc-input v-model="file.FileName" :disabled="true"></cc-input>
                </cc-col>
            </cc-row>
            <cc-row>
                <cc-col w="40">
                    Kích thước(kb)
                </cc-col>
                <cc-col w="60">
                    <cc-input v-model="file.Size" :disabled="true"></cc-input>
                </cc-col>
            </cc-row>
            <cc-row>
                <cc-col w="40">
                    Thư mục cha
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
                    Ghi chú
                </cc-col>
                <cc-col w="60">
                    <cc-input :height="72" v-model="file.Note"></cc-input>
                </cc-col>
            </cc-row>
            <div class="footer">
                <cc-button type="primary" @click="uploadFile" :loading="loading">
                    Tải lên
                </cc-button>
            </div>
        </cc-popup>
    </div>
</template>
<script>
import FileAPI from '@/api/Components/FileAPI.js';
import CcSelectBox from '../../components/select-box/ccSelectBox.vue';
import CcRadio from '../../components/radio/ccRadio.vue';
export default {
    props: {
        value:{
            type: [String,Boolean],
            default: false
        },
        fileName: {
            type: String,
            default: null
        },
        size: {
            type: String,
            default: null
        },
        listFolder: {
            type: Array,
            default: () => []
        }
    },
    data(){
        return{
            loading: false,
            optionFiles: ["Tải lên", "Cá nhân"],
            optionValue: "Tải lên",
            file: {
                FileName: null,
                Note: null,
                TypeFile: "Folder",
                TenantID: null,
                CreatedBy: null
            },
        }
    },
    methods: {
        close(){
            this.$emit("input",false);
        },
        uploadFile(){
            debugger
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
        getFilePersonal(){
            var me = this;
            let param = {
                TenantID: this.$store.getters.tenantID,
                EmployeeID: this.$store.getters.employeeID
            }
            this.loading = true;
            FileAPI.GetPersonal(param).then(res => {
                this.loading = false;
                if(res.data && res.data.Success){
                    me.close();
                }
            });
        }
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