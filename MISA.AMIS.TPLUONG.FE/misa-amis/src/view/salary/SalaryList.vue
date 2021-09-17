<template>
  <div class="content">
    <div class="header-content flex">
      <TitleSalary />
      <div class="box-btn-add">
        <button class="m-btn btn-add" @click="openModal">
          <div class="icon-add"></div>
          <div class="text-btn">Thêm mới</div>
        </button>
      </div>
    </div>
    <div class="toolbar-content flex relative" v-if="countRowChecked == 0">
      <div class="box-search relative">
        <input
          type="text"
          class="m-input input-search"
          placeholder="Tìm kiếm"
        />
        <div class="icon-search"></div>
      </div>
      <div class="toolbar-right flex" >
        <BaseDropdown style="margin-right:20px"
          :data="statusData"
          :widthDropdown = 120
          :widthDropdownData = 230
          :topDropdownData = 42
          :rightDropdownData = 0
          @get="getValueStatus"
        />
        <BaseDropdownSingle style="margin-right: 20px;width: 316px"
          :treeDataSource="treeDataSource"
          :placeholderProp = "'Tất cả đơn vị'"
          :valueExprProp = "'OrganizationUnitID'"
          :displayExprProp = "'OrganizationUnitName'"
          :parentIdExprProp = "'ParentID'"
          :valueDefault = treeDataSource[0].OrganizationUnitID
         />
        <div class="box-filter-toolbar">
          <div class="icon-filter-toolbar"></div>
        </div>
        <div class="box-setting-toolbar">
          <div class="icon-setting-toolbar"></div>
        </div>
      </div>
    </div>
    <div class="toolbar-content flex relative " v-else>
      <span class="text-toolbar">Đã chọn  <b>{{countRowChecked}}</b></span>
      <span class="uncheck-all" @click="uncheckAll">Bỏ chọn</span>
      <div class="box-btn-unfollow-all ">
        <button class="m-btn btn-unfollow-all">
          <div class="icon-unfollow"></div>
          <div class="text-btn">Ngừng theo dõi</div>
        </button>
      </div>
      <div class="box-btn-deletes">
        <button class="m-btn btn-deletes">
          <div class="icon-deletes"></div>
          <div class="text-btn">Xoá</div>
        </button>
      </div>
    </div>
    <div class="table-salary">
      <BaseGrid 
        ref="baseGrid"
        :headers="headers"
        :dataSource="dataSource"
        @getRowChecked="getRowChecked"
       >
       <template #Status ="{data}">
         <div class="box-status flex a-l-c">
           <div class="icon-status"></div>
           <div class="text-status">{{data.Status}}</div>
         </div>
       </template>
       </BaseGrid>

      <div class="paging">
        <div class="amount">Tổng số bản ghi: <b>175</b></div>
        <div class="pagination flex a-l-c ">
          <span style="margin-right:20px">Số bản ghi/trang</span>
          <BaseDropdown style="margin-right:60px"
          :data="dataPage"
          :widthDropdown = 60
          :widthDropdownData = 60
          :topDropdownData = -150
          :rightDropdownData = 10
          @get="getValuePageSize"
        />
          <div class="pageIndex flex a-l-c">
            <span style="margin-right:20px"><b>1</b>-<b>100</b> bản ghi 1 trang</span>
            <i class="fas fa-chevron-left"></i>
            <i class="fas fa-chevron-right"></i>
          </div>
        </div>
      </div>
    </div>
    <SalaryDetail 
      :isOpenModal="isOpenModal"
      @closeForm="closeForm"
    />
  </div>
</template>

<script>
import TitleSalary from "../../components/base/BaseTitle.vue";
// import BaseDropdown from "../../components/base/BaseDropdown.vue";
import BaseDropdownSingle from "../../components/base/BaseDropdownSingle.vue";
import BaseGrid from "../../components/base/BaseGrid.vue";
import SalaryDetail from "../salary/SalaryDetail.vue";
import { TREE_DATA_SOURCE_FILTER } from "../../js/common/data.js";
import BaseDropdown from "../../components/base/BaseDropdown.vue";
export default {
  name: "SalaryList",
  components: {
    TitleSalary,
    // BaseDropdown,
    BaseDropdownSingle,
    BaseGrid,
    SalaryDetail,
    BaseDropdown,
  },
  data() {
    return {
      // mở modal
      isOpenModal: true,
      // data source treeview
      treeDataSource: TREE_DATA_SOURCE_FILTER,
      // value status
      valueStatus : null,
      // value pageSize
      valuePageSize : null,
      // count rowchecked
      countRowChecked: 0,
      // data source grid
      dataSource: [
        {
          SalaryCompositionID : 0,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 1,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Long",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 2,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 3,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 4,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 5,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 6,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 7,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 8,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 9,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
        {
          SalaryCompositionID : 10,
          SalaryCompositionCode: "LUONG_SAN_PHAM",
          SalaryCompositionName: "Lương sản phẩm",
          ApplicableUnit: "Công ty TNHH Kim Đồng",
          IngredientType: "Sản phẩm",
          Nature: "Khấu trừ",
          Price: "Tiền tệ",
          Status: "Đang hoạt động"
        },
      ],
      // header grid
      headers : [
        {
          DataField: "SalaryCompositionCode",
          Caption: "Mã thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: true,
        },
        {
          DataField: "SalaryCompositionName",
          Caption: "Tên thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: true,
        },
        {
          DataField: "ApplicableUnit",
          Caption: "Đơn vị áp dụng",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "IngredientType",
          Caption: "Loại thành phần",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Nature",
          Caption: "Tính chất",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Price",
          Caption: "Giá trị",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
        {
          DataField: "Status",
          Caption: "Trạng thái",
          DataType: "text",
          Alignment: "left",
          Fixed: false,
        },
      ],
      statusData: [
        { Text: "Tất cả trạng thái", Value: 1 },
        { Text: "Đang theo dõi", Value: 2 },
        { Text: "Ngừng theo dõi", Value: 3 },
      ],
      dataPage: [
        { Text: "15", Value: 15 },
        { Text: "25", Value: 25 },
        { Text: "50", Value: 50 },
        { Text: "100", Value: 100 },
      ],
    }
  },
  methods: {
    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(14/09/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
    },

    /**---------------------------------------------------------
     * Bắt sự kiện đóng form chi tiết
     * CreatedBy : LQNHAT(14/09/2021)
     */
    closeForm() {
      this.isOpenModal = true;
    },

    /**-----------------------------------
     * Set value cho status để filter
     * CreatedBy : LQNHAT(14/09/2021)
     */
    getValueStatus(value)
    {
      this.valueStatus = value;
      console.log(this.valueStatus);
    },

    /**------------------------------------
     * Set value cho pageSize
     * CreatedBy: LQNHAT(16/09/2021)
     */
    getValuePageSize(value)
    {
      this.valuePageSize = value;
      console.log(this.valuePageSize);
    },

    /**---------------------------------------------------------
     * Lấy ra số dòng đã được checked
     * CreatedBy: LQNHAT(17/09/2021)
     */
    getRowChecked(selectedRowsData)
    {
      this.countRowChecked = selectedRowsData.length;
    },

    uncheckAll()
    {
      this.$refs.baseGrid.uncheckAllRow();
    }
  },
};
</script>

<style>
</style>