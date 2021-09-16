<template>
  <div class="dx-field-value">
    <DxDropDownBox
      :value="treeBoxValue"
      :show-clear-button="true"
      :data-source="treeDataSource"
      :value-expr="valueExprProp"
      :display-expr="displayExprProp"
      :placeholder="placeholderProp"
      @value-changed="syncTreeViewSelection($event)"
    >
      <template #content="{}">
        <DxTreeView
          :searchEnabled="true"
          :value="treeBoxValue"
          placeholder=" Tìm kiếm"
          noDataText="Không có dữ liệu"
          ref="treeView"
          :data-source="treeDataSource"
          :select-by-click="true"
          :select-nodes-recursive="true"
          data-structure="plain"
          :key-expr="valueExprProp"
          :parent-id-expr="parentIdExprProp"
          selection-mode="multiple"
          show-check-boxes-mode="normal"
          :display-expr="displayExprProp"
          @content-ready="syncTreeViewSelection($event)"
          @item-selection-changed="treeView_itemSelectionChanged($event)"
        />
      </template>

      <!-- <template #list-item="{data}">
        <div class="dx-field-value">
          <DxTextBox :value="data" style="height:3px !important"/>
          <DxTagBox
            :data-source="treeDataSource"
            :value-expr="valueExprProp"
            :display-expr="displayExprProp"
          />

        </div>
      </template> -->
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
// import DxTextBox from 'devextreme-vue/text-box';
// import DxTagBox from "devextreme-vue/tag-box";
export default {
  name: "BaseDropdownMulti",
  components: {
    DxDropDownBox,
    DxTreeView,
    // DxTextBox
    // DxTagBox,
  },
  props: [
    "treeDataSource",
    "placeholderProp",
    "valueExprProp",
    "displayExprProp",
    "parentIdExprProp",
    "valueDefault",
  ],
  data() {
    return {
      treeBoxValue: null,
      treeViewName: "treeView",
    };
  },
  created() {
    // set value default cho dropdown single
    var seft = this;
    seft.treeBoxValue = [seft.valueDefault];
    // setTimeout(() => {
    //   self.$refs.treeView.instance.selectItem(self.treeBoxValue);
    // },500)
  },
  methods: {
    syncTreeViewSelection(e) {
      console.log("value-changed: " + e.value);
      let treeView =
        (e.component.selectItem && e.component) ||
        (this.$refs[this.treeViewName] &&
          this.$refs[this.treeViewName].instance);

      if (treeView) {
        if (e.value === null) {
          treeView.unselectAll();
        } else {
          let values = e.value || this.treeBoxValue;
          console.log("số lượng item: " + values.length);
          //   values &&
          //     values.forEach((value) => {
          //       treeView.selectItem(value);
          //     });
          for (let index = 0; index < values.length; index++) {
            treeView.selectItem(values[index]);
          }
        }
      }
    },
    treeView_itemSelectionChanged(e) {
      console.log(e);
      this.treeBoxValue = e.component.getSelectedNodeKeys();
      console.log("treeBoxValue: " + this.treeBoxValue);
    },
  },
};
</script>

<style>
@import "../../css/base/dropdown-multi.css";
</style>