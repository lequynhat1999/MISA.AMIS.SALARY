<template>
  <div id="myModal" class="modal" :class="{ 'hidden-modal': isOpenModal }">
    <div class="modal-content">
      <div class="header-form flex">
        <div
          class="box-icon-back"
          v-shortkey="['esc']"
          @shortkey="closeFormDetail"
          title="Quay lại (ESC)"
          @click="closeFormDetail"
        >
          <div class="icon-back"></div>
        </div>
        <div class="title-form" v-if="mode == 0">
          <span>Thêm thành phần</span>
        </div>
        <div class="title-form" v-else>
          <span>{{ salaryComposition.SalaryCompositionName }}</span>
        </div>
        <div class="box-btn-header flex" v-if="mode == 0">
          <div class="btn-cancel-form m-r-8">
            <button class="m-btn-white" @click="closeFormDetail">
              <div class="text-btn">Hủy bỏ</div>
            </button>
          </div>
          <div class="btn-save-add-form m-r-8">
            <button
              class="m-btn-white"
              @click="saveAndAddClick"
              title="Lưu và thêm (Ctrl + Shift + S)"
              v-shortkey="['ctrl', 'shift', 's']"
              @shortkey="saveAndAddClick"
            >
              <div class="text-btn">Lưu và thêm</div>
            </button>
          </div>
          <div
            class="btn-add-form"
            @click="saveBtnClick"
            title="Lưu (Ctrl + S)"
            v-shortkey="['ctrl', 's']"
            @shortkey="saveBtnClick"
          >
            <button class="m-btn m-btn-add">
              <div class="text-btn">Lưu</div>
            </button>
          </div>
        </div>
        <div class="box-btn-header flex" v-else>
          <div class="btn-add-form" @click="openBoxBtn" v-if="hiddenBoxBtn">
            <button class="m-btn m-btn-add btn-edit-detail">
              <div class="text-btn">Sửa</div>
            </button>
          </div>
          <div class="box-btn-detail flex" v-else>
            <div class="btn-cancel-form m-r-8" @click="closeBoxBtn">
              <button class="m-btn-white">
                <div class="text-btn">Hủy bỏ</div>
              </button>
            </div>
            <div class="btn-add-form" @click="saveBtnClick">
              <button class="m-btn m-btn-add btn-edit-detail">
                <div class="text-btn">Lưu</div>
              </button>
            </div>
          </div>

          <div
            class="box-context-menu"
            @click="toggleContextMenu"
            :class="{ 'box-content-active': !hiddenContextMenu }"
          >
            <div class="icon-context"></div>
            <div class="context-menu-data" v-if="!hiddenContextMenu">
              <div class="box-item-context">
                <div class="item-context flex a-l-c" @click="cloneSalaryToForm">
                  <div class="icon-item-context"></div>
                  <div class="text-item-context">Nhân bản</div>
                </div>
                <div class="item-context flex a-l-c" @click="deleteToForm">
                  <div class="icon-item-context icon-context-delete"></div>
                  <div class="text-item-context text-context-delete">Xóa</div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <ValidationObserver ref="form_salary">
        <div class="content-form">
          <div class="content-wrapper">
            <div class="flex">
              <div class="text-input">
                <b>Tên thành phần <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <input
                  type="text"
                  ref="salaryCompositionName"
                  v-model="salaryComposition.SalaryCompositionName"
                  class="m-input input-text-form"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                    'view-read': hiddenBoxBtn,
                  }"
                  @input="generateCode"
                  :disabled="hiddenBoxBtn"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Mã thành phần <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <input
                  type="text"
                  v-model="salaryComposition.SalaryCompositionCode"
                  class="m-input input-text-form"
                  placeholder="Nhập mã viết liền"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                    'view-read': hiddenBoxBtn,
                  }"
                  :disabled="hiddenBoxBtn"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Đơn vị áp dụng <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <DropdownMulti
                  style="margin-left: 24px; width: 629px"
                  :treeDataSource="treeDataSource"
                  :placeholderProp="''"
                  :valueExprProp="'OrganizationUnitID'"
                  :displayExprProp="'OrganizationUnitName'"
                  :parentIdExprProp="'ParentID'"
                  :hiddenBoxBtn="hiddenBoxBtn"
                  v-model="salaryComposition.OrganizationUnitID"
                  :class="{
                    'border-red-component': errors.length > 0 ? true : false,
                  }"
                  @getListSelected="getListSelected"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Loại thành phần <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <SelectBox
                  style="margin-left: 25px; width: 237px"
                  :dataSource="dataSourceType"
                  :hiddenBoxBtn="hiddenBoxBtn"
                  :valueExprProp="'SalaryCompositionTypeID'"
                  :displayExprProp="'SalaryCompositionTypeName'"
                  :disabledProp="hiddenBoxBtn"
                  v-model="salaryComposition.SalaryCompositionTypeID"
                  :class="{
                    'border-red-component': errors.length > 0 ? true : false,
                  }"
                  :borderRed="errors.length > 0 ? true : false"
                />
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Tính chất <span style="color: red">*</span></b>
              </div>
              <ValidationProvider rules="validateRequired" v-slot="{ errors }">
                <div class="box-validate">
                  <SelectBox
                    style="margin-left: 25px; width: 237px"
                    :displayExprProp="'NatureName'"
                    :hiddenBoxBtn="hiddenBoxBtn"
                    :valueExprProp="'NatureID'"
                    :dataSource="dataSourceNature"
                    :disabledProp="hiddenBoxBtn"
                    v-model="salaryComposition.NatureID"
                    :class="{
                      'border-red-component': errors.length > 0 ? true : false,
                    }"
                  />
                </div>
                <div v-if="errors.length > 0">
                  <div class="text-error">{{ errors[0] }}</div>
                </div>
              </ValidationProvider>
              <div class="box-earning" v-if="salaryComposition.NatureID == 1">
                <div class="earning-wrapper flex a-l-c">
                  <DxRadioGroup
                    :dataSource="dataSourceTax"
                    :display-expr="'TaxableName'"
                    :value-expr="'TaxableID'"
                    :value="dataSourceTax[0].TaxableID"
                    layout="horizontal"
                    v-model="salaryComposition.TaxableID"
                  />
                </div>
              </div>
              <div class="box-earning" v-if="salaryComposition.NatureID == 2">
                <div class="deduct-wrapper flex">
                  <DxCheckBox
                    :width="550"
                    text="Giảm trừ khi tính thuế"
                    :value="false"
                    v-model="salaryComposition.ReduceBoolean"
                  />
                </div>
              </div>
            </div>
            <div class="input-form flex" v-if="salaryComposition.NatureID != 3">
              <div class="text-input flex">
                <b>Định mức</b>
                <div
                  class="icon-quota"
                  title="Khi tính giá trị của thành phần lương này, nếu số tiền vượt quá định mức thì chương trình sẽ tự động lấy mức tối đa theo định mức đã thiết lập"
                ></div>
              </div>
              <money
                type="text"
                class="m-input input-text-form"
                :class="{ 'view-read': hiddenBoxBtn }"
                :disabled="hiddenBoxBtn"
                style="text-align: right"
                value=""
                v-bind="money"
                v-model="salaryComposition.Quota"
              ></money>
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Kiểu giá trị</b>
              </div>
              <SelectBox
                style="margin-left: 25px; max-width: 237px"
                :hiddenBoxBtn="hiddenBoxBtn"
                :displayExprProp="'ValueTypeName'"
                :valueExprProp="'ValueTypeID'"
                :dataSource="dataSourceValueType"
                :disabledProp="salaryComposition.NatureID == 3 ? false : true"
                v-model="salaryComposition.ValueTypeID"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Giá trị</b>
              </div>
              <textarea
                class="m-input input-text-form"
                :class="{
                  'view-read': hiddenBoxBtn,
                  'height-textarea': hiddenBoxBtn,
                }"
                :disabled="hiddenBoxBtn"
                placeholder="Tự động gợi ý công thức và tham số khi gõ"
                style="height: 71px"
                v-model="salaryComposition.Cost"
              />
            </div>
            <div class="input-form flex">
              <div class="text-input">
                <b>Mô tả</b>
              </div>
              <textarea
                class="m-input input-text-form"
                :class="{
                  'view-read': hiddenBoxBtn,
                  'height-textarea': hiddenBoxBtn,
                }"
                :disabled="hiddenBoxBtn"
                style="height: 71px"
                v-model="salaryComposition.Description"
              />
            </div>
            <div class="box-status-radio" v-if="mode == 1">
              <DxRadioGroup
                :dataSource="dataSourceStatus"
                :display-expr="'Text'"
                :value-expr="'Value'"
                :value="dataSourceStatus[0].Value"
                layout="horizontal"
                v-model="salaryComposition.StatusID"
              />
            </div>
          </div>
        </div>
      </ValidationObserver>
    </div>
  </div>
</template>

<script>
import SelectBox from "../../components/base/BaseSelectBox.vue";
import DropdownMulti from "../../components/base/BaseDropdownMulti.vue";
import DxRadioGroup from "devextreme-vue/radio-group";
import { extend } from "vee-validate";
import { required } from "vee-validate/dist/rules";
import { DxCheckBox } from "devextreme-vue/check-box";
import { Money } from "v-money";
import {MODE} from "../../js/common/mode";
import axios from "axios";
import {
  NATURE,
  VALUE_TYPE,
  URL_API,
  STATUS_DATA,
  TAX,
} from "../../js/common/data.js";
import {MESSAGE} from "../../js/common/message";
extend("validateRequired", {
  ...required,
  message: "Không được để trống",
});

export default {
  name: "SalaryDetail",
  components: {
    SelectBox,
    DropdownMulti,
    DxCheckBox,
    DxRadioGroup,
    Money,
  },
  // props: ["isOpenModal", "treeDataSource"],
  props: {
    isOpenModal: {
      type: Boolean,
    },
    treeDataSource: {
      type: Array,
    },
  },
  data() {
    return {
      // v-money
      money: {
        decimal: ",",
        thousands: ",",
        precision: 0,
        masked: false,
      },
      // dataSource selectbox
      dataSourceType: [],
      dataSourceNature: NATURE,
      dataSourceValueType: VALUE_TYPE,
      dataSourceStatus: STATUS_DATA,
      // id của item
      isShowRadio: false,
      // value default cho input tính chất
      itemID: 1,
      // data cho radio
      dataSourceTax: TAX,
      // ẩn contextmenu
      hiddenContextMenu: true,
      // ẩn box btn
      hiddenBoxBtn: true,
      // mode để check trạng thái form
      mode: MODE.ADD,
      // ID  thành phần lương
      salaryCompositionID: "",
      // Thành phần lương
      salaryComposition: {},
      // check trùng mã
      isDuplicate: false,
      // mảng thành phần lương
      salaryCompositions: [],
      // object check data change
      salaryCompositionOriginalAdd: {},
      salaryCompositionOriginalEdit: {},
      value: [],
    };
  },
  created() {
    // lấy danh sách loại thành phần
    this.getSalaryCompositionType();
    // lấy ra toàn bộ danh sách thành phần lương
    this.getSalaryComposition();
  },

  methods: {
    /**--------------------------------------------
     * Hàm check mode
     * CreateBy : LQNHAT(21/09/2021)
     */
    show(mode, id) {
      this.hiddenBoxBtn = false;
      this.mode = mode;
      this.salaryCompositionID = id;
      this.$refs.form_salary.reset();
      // mode == 0 thì add
      if (mode == MODE.ADD) {
        this.salaryComposition = {
          OrganizationUnitID: ["9b6e83a4-38d5-4184-a44f-2f202ea6c814"],
          OrganizationUnitName: [""],
          SalaryCompositionTypeID: "",
          NatureID: 1,
          TaxableID: 0,
          ValueTypeID: 2,
          ReduceBoolean: false,
          Quota: 0,
        };
        Object.assign(
          this.salaryCompositionOriginalAdd,
          this.salaryComposition
        );
        // focus vào ô tên thành phần
        this.$nextTick(() => this.$refs.salaryCompositionName.focus());
      }
      // mode == 1 thì bind data lên form
      else {
        this.hiddenBoxBtn = true;
        this.bindDataToForm();
      }
    },

    /**-------------------------------------------------------------------------------------
     * Nhân bản
     * CreatedBy: LQNHAT(23/09/2021)
     */
    cloneSalaryComposition(data) {
      this.mode = MODE.ADD;
      this.hiddenBoxBtn = false;
      this.salaryComposition = {};
      this.$refs.form_salary.reset();
      // chuyển thành arr
      let arrID = data.OrganizationUnitID;
      let arrName = data.OrganizationUnitName;
      arrID = arrID.split(",");
      arrName = arrName.split(",");

      this.salaryComposition.SalaryCompositionID =
        "00000000-0000-0000-0000-000000000000";
      this.$set(this.salaryComposition, "OrganizationUnitID", arrID);
      this.$set(this.salaryComposition, "OrganizationUnitName", arrName);
      this.$set(
        this.salaryComposition,
        "SalaryCompositionTypeID",
        data.SalaryCompositionTypeID
      );
      this.$set(this.salaryComposition, "NatureID", data.NatureID);
      this.$set(this.salaryComposition, "TaxableID", data.TaxableID);
      this.$set(this.salaryComposition, "ReduceBoolean", data.ReduceBoolean);
      this.$set(this.salaryComposition, "ValueTypeID", data.ValueTypeID);
      // focus vào ô tên thành phần
      this.$nextTick(() => this.$refs.salaryCompositionName.focus());
    },

    /**-----------------------------------------------------------------------
     * Bắt sự kiện click nút lưu
     * CreatedBy: LQNHAT(21/09/2021)
     */
    saveBtnClick() {
      this.checkDuplicateCode();
      // validate check trùng mã
      if (this.isDuplicate == true) {
        this.$toast.error(MESSAGE.TEXT_ERROR_DUPLICATE_CODE, {
          timeout: 2000,
        });
        this.isDuplicate = false;
        return;
      }
      // validate cả form
      this.$refs.form_salary.validate().then((success) => {
        if (!success) {
          return;
        }
        if (this.mode == MODE.ADD) {
          this.addSalaryComposition();
          this.closeForm();
        } else {
          this.editSalaryComposition();
          this.closeForm();
          this.hiddenBoxBtn = true;
        }
      });
    },

    /**-----------------------------------------------------------------
     * Bắt sự kiện click lưu và thêm
     * CreatedBy: LQNHAT(23/09/2021)
     */
    saveAndAddClick() {
      // validate check trùng mã
      if (this.isDuplicate == true) {
        this.$toast.error(MESSAGE.TEXT_ERROR_DUPLICATE_CODE, {
          timeout: 2000,
        });
        this.isDuplicate = false;
        return;
      }
      // validate cả form
      this.$refs.form_salary.validate().then((success) => {
        if (!success) {
          return;
        }
        if (this.mode == MODE.ADD) {
          this.addSalaryComposition();
          this.salaryComposition = {};
          this.salaryComposition = {
            OrganizationUnitID: ["9b6e83a4-38d5-4184-a44f-2f202ea6c814"],
            SalaryCompositionTypeID: [""],
            NatureID: 1,
            TaxableID: 0,
            ValueTypeID: 2,
            ReduceBoolean: false,
            Quota: 0,
          };
          this.mode = MODE.ADD;
          this.$refs.form_salary.reset();
          this.$nextTick(() => this.$refs.salaryCompositionName.focus());
        }
      });
    },

    /**-------------------------------------------------------
     * Lấy ra toàn bộ danh sách thành phần lương
     * CreatedBy: LQNHAT(21/09/2021)
     */
    getSalaryComposition() {
      var self = this;
      axios.get(URL_API.API_SALARYCOMPOSITION).then((res) => {
        self.salaryCompositions = res.data;
      });
    },

    /**---------------------------------------------------------------
     * Lấy ra mảng dữ liệu đã chọn từ dropdown multi
     * CreatedBy: LQNHAT(24/09/2021)
     */
    getListSelected(value) {
      this.value = value;
      // gán array
      let arrID = [];
      value.forEach((element) => {
        arrID.push(element.key);
      });
      let arrName = [];
      value.forEach((element) => {
        arrName.push(element.text);
      });
      this.salaryComposition.OrganizationUnitID = arrID;
      this.salaryComposition.OrganizationUnitName = arrName;
    },

    /**------------------------------------------------------
     * Check trùng mã
     * CreatedBy: LQNHAT(21/09/2021)
     */
    checkDuplicateCode() {
      this.salaryCompositions.forEach((element) => {
        if (
          this.salaryComposition.SalaryCompositionCode ==
            element.SalaryCompositionCode &&
          this.salaryComposition.SalaryCompositionID !=
            element.SalaryCompositionID
        ) {
          this.isDuplicate = true;
        }
      });
    },

    /**----------------------------------------------------------------------
     * Thêm mới thành phần lương
     * CreatedBy: LQNHAT(21/09/2021)
     */
    addSalaryComposition() {
      var self = this;
      // chuyển thành string
      let strID = "";
      this.value.forEach((element) => {
        strID += element.key + ",";
      });
      let strName = "";
      this.value.forEach((element) => {
        strName += element.text + ",";
      });
      strID = strID.slice(0, -1);
      this.salaryComposition.OrganizationUnitID = strID;
      strName = strName.slice(0, -1);
      this.salaryComposition.OrganizationUnitName = strName;
      axios
        .post(URL_API.API_SALARYCOMPOSITION, self.salaryComposition)
        .then(() => {
          self.$emit("reloadTableAndFilter");
          self.$toast.success(MESSAGE.TEXT_SUCCESS_ADD, {
            timeout: 2000,
          });
        });
    },

    /**---------------------------------------------------------------------------
     * Sửa thông tin thành phần lương
     * CreatedBy: LQNHAT(21/09/2021)
     */
    editSalaryComposition() {
      var self = this;
      let strID = "";
      let strName = "";
      let arrID = self.salaryComposition.OrganizationUnitID;
      let arrName = self.salaryComposition.OrganizationUnitName;
      // ID string
      arrID.forEach((element) => {
        strID += element + ",";
      });
      strID = strID.slice(0, -1);
      self.salaryComposition.OrganizationUnitID = strID;

      // Name string
      arrName.forEach((element) => {
        strName += element + ",";
      });
      strName = strName.slice(0, -1);
      self.salaryComposition.OrganizationUnitName = strName;

      axios
        .put(
          URL_API.API_SALARYCOMPOSITION + "/" + self.salaryCompositionID,
          self.salaryComposition
        )
        .then(() => {
          self.$emit("reloadTableAndFilter");
          self.$toast.success(MESSAGE.TEXT_SUCCESS_EDIT, {
            timeout: 2000,
          });
        });
    },

    /**----------------------------------------------------------------------------
     * Lấy ra toàn bộ danh sách loại thành phần
     * CreatedBy: LQNHAT(21/09/2021)
     */
    getSalaryCompositionType() {
      var self = this;
      axios.get(URL_API.API_SALARYCOMPOSITIONTYPE).then((res) => {
        self.dataSourceType = res.data;
      });
    },

    /**-------------------------------------------------------------------------
     * Bind dữ liệu lên trên form
     * CreatedBy: LQNHAT(21/09/2021)
     */
    bindDataToForm() {
      var self = this;
      axios
        .get(URL_API.API_SALARYCOMPOSITION + "/" + self.salaryCompositionID)
        .then((res) => {
          self.salaryComposition = res.data;
          let arrID = res.data.OrganizationUnitID;
          let arrName = res.data.OrganizationUnitName;
          arrID = arrID.split(",");
          arrName = arrName.split(",");
          // dạng array
          self.salaryComposition.OrganizationUnitID = arrID;
          self.salaryComposition.OrganizationUnitName = arrName;
          Object.assign(self.salaryCompositionOriginalEdit, res.data);
        });
    },

    /**---------------------------------------------------------------------------
     * Nhân bản trong form detail
     * CreatedBy: LQNHAT(23/09/2021)
     */
    cloneSalaryToForm() {
      this.hiddenBoxBtn = false;
      this.mode = MODE.ADD;
      this.salaryComposition = {};
      this.$refs.form_salary.reset();
      this.salaryComposition.SalaryCompositionID =
        "00000000-0000-0000-0000-000000000000";
      this.$set(
        this.salaryComposition,
        "OrganizationUnitID",
        this.salaryCompositionOriginalEdit.OrganizationUnitID
      );
      this.$set(
        this.salaryComposition,
        "OrganizationUnitName",
        this.salaryCompositionOriginalEdit.OrganizationUnitName
      );
      this.$set(
        this.salaryComposition,
        "SalaryCompositionTypeID",
        this.salaryCompositionOriginalEdit.SalaryCompositionTypeID
      );
      this.$set(
        this.salaryComposition,
        "NatureID",
        this.salaryCompositionOriginalEdit.NatureID
      );
      this.$set(
        this.salaryComposition,
        "TaxableID",
        this.salaryCompositionOriginalEdit.TaxableID
      );
      this.$set(
        this.salaryComposition,
        "ReduceBoolean",
        this.salaryCompositionOriginalEdit.ReduceBoolean
      );
      this.$set(
        this.salaryComposition,
        "ValueTypeID",
        this.salaryCompositionOriginalEdit.ValueTypeID
      );
      // focus vào ô tên thành phần
      this.$nextTick(() => this.$refs.salaryCompositionName.focus());
    },

    /**----------------------------------------------------------------------------
     * Xóa trong form detail
     * CreatedBy: LQNHAT(23/09/2021)
     */
    deleteToForm() {
      this.$emit("openPopupDelete", this.salaryComposition);
    },

    /*-----------------------------------------------------------------------------
     * Lấy ra value của dropdown multi
     * CreatedBy: LQNHAT(26/09/2021)
     */
    getTreeBoxValue(value) {
      this.salaryComposition.OrganizationUnitID = value;
    },

    /*--------------------------------------
     * Sinh mã code
     * CreatedBy: LQNHAT(22/09/2021)
     */
    generateCode() {
      this.$set(
        this.salaryComposition,
        "SalaryCompositionCode",
        this.nonAccentVietnamese(this.salaryComposition.SalaryCompositionName)
          .toUpperCase()
          .split(" ")
          .join()
          .replaceAll(",", "_")
      );
    },

    /**------------------------------------------------------------------------------------------
     * Chuyển tiếng việt thành tiếng anh
     * CreatedBy: LQNHAT(22/09/2021)
     */
    nonAccentVietnamese(str) {
      str = str.toLowerCase();
      str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
      str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
      str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
      str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
      str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
      str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
      str = str.replace(/đ/g, "d");
      str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ""); // Huyền sắc hỏi ngã nặng
      str = str.replace(/\u02C6|\u0306|\u031B/g, ""); // Â, Ê, Ă, Ơ, Ư
      return str;
    },

    /**------------------------------------------------------------------------------
     * Sự kiện click nút <-
     * CreatedBy: LQNHAT(15/09/2021)
     */
    closeFormDetail() {
      // check mode = 0
      if (this.mode == MODE.ADD) {
        // check data change
        if (
          JSON.stringify(Object.values(this.salaryCompositionOriginalAdd)) ===
          JSON.stringify(Object.values(this.salaryComposition))
        ) {
          // close form
          this.closeForm();
        } else {
          // mở popup
          this.$emit("openPopupDataChange");
        }
      } else {
        // check data change
        if (
          JSON.stringify(Object.values(this.salaryCompositionOriginalEdit)) ===
          JSON.stringify(Object.values(this.salaryComposition))
        ) {
          // close form
          this.closeForm();
        } else {
          // mở popup
          this.$emit("openPopupDataChange");
        }
      }
    },

    /**---------------------------------------------------------------------------
     * Đóng form
     * CreatedBy: LQNHAT(23/09/2021)
     */
    closeForm() {
      this.$emit("closeForm");
      this.$refs.form_salary.reset();
    },

    /*------------------------------------------------------------------
     * Bắt sự kiện close box btn
     * CreatedBy: LQNHAT(21/09/2021)
     */
    closeBoxBtn() {
      this.hiddenBoxBtn = true;
    },

    /*------------------------------------------------------------------
     * Bắt sự kiện open box btn
     * CreatedBy: LQNHAT(21/09/2021)
     */
    openBoxBtn() {
      this.hiddenBoxBtn = false;
      this.$nextTick(() => this.$refs.salaryCompositionName.focus());
    },

    /**-------------------------------------------------------
     * Bắt sự kiện toggle contextmenu
     * CreatedBy: LQNHAT(21/09/2021)
     */
    toggleContextMenu() {
      this.hiddenContextMenu = !this.hiddenContextMenu;
      event.stopPropagation();
    },

    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài context
     * CreateBy: LQNhat(21/09/2021)
     */
    close() {
      if (this.hiddenContextMenu == false) {
        this.hiddenContextMenu = true;
      }
    },
  },
  mounted() {
    document.addEventListener("click", this.close);
  },
};
</script>

<style>
</style>