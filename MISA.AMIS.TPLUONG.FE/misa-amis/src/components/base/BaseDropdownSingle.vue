<template>
  <div class="dx-field-value">
    <DxDropDownBox
      :value="treeBoxValue"
      :opened="isTreeBoxOpened"
      :show-clear-button="true"
      :data-source="treeDataSource"
      value-expr="ID"
      display-expr="name"
      placeholder=""
      @value-changed="syncTreeViewSelection($event)"
    >
      <template #content="{}">
        <DxTreeView
          :searchEnabled="true"
          :ref="treeViewRefName"
          :data-source="treeDataSource"
          :select-by-click="true"
          data-structure="plain"
          key-expr="ID"
          parent-id-expr="categoryId"
          selection-mode="single"
          display-expr="name"
          @content-ready="$event.component.selectItem(treeBoxValue)"
          @item-selection-changed="treeView_itemSelectionChanged($event)"
          @item-click="onTreeItemClick($event)"
        />
      </template>
    </DxDropDownBox>
  </div>
</template>

<script>
import DxDropDownBox from "devextreme-vue/drop-down-box";
import DxTreeView from "devextreme-vue/tree-view";
import CustomStore from 'devextreme/data/custom_store';
// import 'whatwg-fetch';
export default {
  name: "BaseDropdownSingle",
  components: {
    DxDropDownBox,
    DxTreeView,
  },
  data() {
      return {
          treeDataSource: null,
          treeBoxValue: null,
          isTreeBoxOpened: false,
          treeViewRefName: "tree-view",
      }
  },
  created() {
    this.treeDataSource = this.makeAsyncDataSource('treeProducts.json');
    this.treeBoxValue = '1_1';
  },
  methods: {
    makeAsyncDataSource(jsonFile) {
      return new CustomStore({
        loadMode: 'raw',
        key: 'ID',
        load: function() {
          return fetch(`https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/data/${ jsonFile}`)
            .then(response => response.json());
        }
      });
    },
    syncTreeViewSelection() {
      if (!this.$refs[this.textBoxRefName]) return;
      if (!this.treeBoxValue) {
        this.$refs[this.textBoxRefName].instance.unselectAll();
      } else {
        this.$refs[this.textBoxRefName].instance.selectItem(this.treeBoxValue);
      }
    },
    treeView_itemSelectionChanged(e) {
      this.treeBoxValue = e.component.getSelectedNodeKeys();
    },
    onTreeItemClick() {
      this.isTreeBoxOpened = false;
    },
  },
};
</script>

<style  scoped>
@import "../../css/base/dropdown-single.css";
</style>